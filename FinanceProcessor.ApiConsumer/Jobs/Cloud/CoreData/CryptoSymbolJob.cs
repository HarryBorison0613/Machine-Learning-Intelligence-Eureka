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
	public class CryptoSymbolJob : IJob
	{
		private IEXCloudClient _sandBoxClient;
		private readonly ILogger<CryptoSymbolJob> _logger;
		private readonly ICryptoSymbolRepository _cryptoSymbolRepository;
		private readonly IMapper _mapper;

		public CryptoSymbolJob(IDataService ds, ILogger<CryptoSymbolJob> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper)
		{
			_cryptoSymbolRepository = ds.CryptoSymbols;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);
			_mapper = mapper;

			_logger = logger;
		}

		public async Task Execute(IJobExecutionContext context)
		{
			_logger.LogInformation("Start CryptoSymbolJob");

			var tasks = new List<Task>();

			try
			{
				var response = await _sandBoxClient.ReferenceData.SymbolCryptoAsync();

				if (response?.Data.Any() != true)
					return;

				var symbols = _mapper.Map<List<CryptoSymbol>>(response.Data);

				foreach (var symbol in symbols)
				{
					var task = _cryptoSymbolRepository.CreateOrReplaceCryptoSymbolAsync(symbol);
					tasks.Add(task);
				}

				var taskToDelete = _cryptoSymbolRepository.DeleteSymbolsIfNeededAsync(symbols);
				tasks.Add(taskToDelete);

				await Task.WhenAll(tasks);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			_logger.LogInformation("End CryptoSymbolJob");
		}
	}
}
