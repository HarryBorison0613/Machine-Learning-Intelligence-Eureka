using AutoMapper;
using FinanceProcessor.IEXSharp;
using FinanceProcessor.IEXSharp.Options;
using FinanceProcessor.MongoDB.Contracts.Entities;
using FinanceProcessor.MongoDB.Contracts.Repositories;
using FinanceProcessor.MongoDB.Contracts.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quartz;

namespace FinanceProcessor.ApiConsumer.Jobs.Cloud.CoreData
{
	public class FXSymbolJob : IJob
	{
		private IEXCloudClient _sandBoxClient;
		private readonly ILogger<FXSymbolJob> _logger;
		private readonly IForexCurrencyRepository _forexCurrencyRepository;
		private readonly IForexPairRepository _forexPairRepository;
		private readonly IMapper _mapper;

		public FXSymbolJob(IDataService ds, ILogger<FXSymbolJob> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper)
		{
			_forexCurrencyRepository = ds.ForexCurrencies;
			_forexPairRepository = ds.ForexPairs;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);
			_mapper = mapper;

			_logger = logger;
		}

		public async Task Execute(IJobExecutionContext context)
		{
			_logger.LogInformation("Start FXSymbolJob");

			var tasks = new List<Task>();

			try
			{
				var response = await _sandBoxClient.ReferenceData.SymbolFXAsync();

				if (response?.Data?.currencies.Any() == true)
				{
					var currencies = _mapper.Map<List<ForexCurrency>>(response.Data.currencies);

					foreach (var currency in currencies)
					{
						if (currencies.Count(c => c.Code == currency.Code) > 1)
						{
							var res = currencies.FindAll(c => c.Code == currency.Code);
						}

						var task = _forexCurrencyRepository.CreateOrReplaceForexCurrencyAsync(currency);
						tasks.Add(task);
					}

					var forexCurrenciesToDelete = _forexCurrencyRepository.DeleteForexCurrencyIfNeededAsync(currencies);

					tasks.Add(forexCurrenciesToDelete);
				}

				if (response?.Data?.pairs.Any() == true)
				{
					var pairs = _mapper.Map<List<ForexPair>>(response.Data.pairs);

					foreach (var pair in pairs)
					{
						var task = _forexPairRepository.CreateOrReplaceForexPairAsync(pair);
						tasks.Add(task);
					}

					var forexPairs = _forexPairRepository.DeleteForexPairIfNeededAsync(pairs);

					tasks.Add(forexPairs);
				}

				await Task.WhenAll(tasks);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			_logger.LogInformation("End FXSymbolJob");
		}
	}
}
