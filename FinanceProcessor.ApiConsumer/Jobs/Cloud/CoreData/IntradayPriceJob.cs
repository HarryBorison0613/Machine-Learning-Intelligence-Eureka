using AutoMapper;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants;
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
	public class IntradayPriceJob : IJob
	{
		private IEXCloudClient _sandBoxClient;
		private readonly ILogger<IntradayPriceJob> _logger;
		private readonly IIntradayPriceRepository _intradayPriceRepository;
		private readonly IMapper _mapper;

		public IntradayPriceJob(IDataService ds, ILogger<IntradayPriceJob> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper)
		{
			_intradayPriceRepository = ds.IntradayPrices;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);

			_logger = logger;
			_mapper = mapper;
		}

		public async Task Execute(IJobExecutionContext context)
		{
			_logger.LogInformation("Start IntradayPriceJob");

			var tasks = new List<Task>();

			foreach (var symbol in Symbols.PopularSymbols)
			{
				var task = ExecuteForSymbol(symbol);
				tasks.Add(task);
			}

			await Task.WhenAll(tasks);

			_logger.LogInformation("End IntradayPriceJob");
		}

		private async Task ExecuteForSymbol(string symbol)
		{
			_logger.LogInformation($"Start  for {symbol}");

			var tasks = new List<Task>();
			try
			{
				var response = await _sandBoxClient.StockPrices.IntradayPricesAsync(symbol);

				if (response?.Data.Any() != true)
					return;

				var intradayPrices = _mapper.Map<List<IntradayPrice>>(response.Data);

				var first = intradayPrices.First();

				await _intradayPriceRepository.DeleteAllAsync(i => i.Symbol == symbol && i.Date != first.Date);

				foreach (var intradayPrice in intradayPrices)
				{
					var task = _intradayPriceRepository.CreateIntradayPriceAsync(intradayPrice, symbol);
					tasks.Add(task);
				}

				await Task.WhenAll(tasks);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			_logger.LogInformation($"End  for {symbol}");
		}
	}
}
