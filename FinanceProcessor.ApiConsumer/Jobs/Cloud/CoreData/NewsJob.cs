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
	public class NewsJob : IJob
	{
		private IEXCloudClient _sandBoxClient;
		private readonly ILogger<NewsJob> _logger;
		private readonly IMapper _mapper;
		private readonly INewsRepository _newsRepository;

		public NewsJob(IDataService ds, ILogger<NewsJob> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper)
		{
			_newsRepository = ds.News;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);

			_logger = logger;
			_mapper = mapper;
		}

		public async Task Execute(IJobExecutionContext context)
		{
			_logger.LogInformation("Start NewsJob");

			var tasks = new List<Task>();

			foreach (var symbol in Symbols.PopularSymbols)
			{
				var task = ExecuteForSymbol(symbol);
				tasks.Add(task);
			}

			await Task.WhenAll(tasks);

			_logger.LogInformation("End NewsJob");
		}

		private async Task ExecuteForSymbol(string symbol)
		{
			_logger.LogInformation($"Start  for {symbol}");

			var tasks = new List<Task>();
			try
			{
				var response = await _sandBoxClient.News.NewsAsync(symbol);

				if (response?.Data.Any() != true)
					return;

				var newsList = _mapper.Map<List<News>>(response.Data);

				await _newsRepository.DeleteAllAsync(i => i.Symbol == symbol);

				foreach (var news in newsList)
				{
					var task = _newsRepository.CreateNewsAsync(news, symbol);
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
