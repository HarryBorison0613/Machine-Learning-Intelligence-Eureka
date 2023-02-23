using AutoMapper;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData;
using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp;
using FinanceProcessor.IEXSharp.Model.CoreData.CorporateActions.Request;
using FinanceProcessor.IEXSharp.Model.CoreData.News.Response;
using FinanceProcessor.IEXSharp.Options;
using FinanceProcessor.MongoDB.Contracts.Entities;
using FinanceProcessor.MongoDB.Contracts.Repositories;
using FinanceProcessor.MongoDB.Contracts.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Services.Cloud.CoreData
{
	public class NewsService : INewsService
	{
		private readonly ILogger<NewsService> _logger;
		private readonly INewsRepository _db;
		private IEXCloudClient _sandBoxClient;
		private readonly IMapper _mapper;

		public NewsService(IDataService ds, ILogger<NewsService> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper)
		{
			_db = ds.News;
			_logger = logger;
			_mapper = mapper;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);
		}

		public async Task<Dictionary<string, NewsDto[]>> GetLastNewsForMostPopularSymbolsAsync()
		{
			_logger.LogInformation("Start GetLastNewsForMostPopularSymbolsAsync");

			var tasks = new List<Task<IEnumerable<News>>>();

			foreach (var symbol in Symbols.PopularSymbols)
			{
				var task = _db.GetNewsBySymbolAsync(symbol);
				tasks.Add(task);
			}

			await Task.WhenAll(tasks);

			var news = tasks
				.Where(t => t.IsCompletedSuccessfully)
				.SelectMany(t => _mapper.Map<IEnumerable<NewsDto>>(t.Result))
				.GroupBy(x => x.Symbol)
				.ToDictionary(g => g.Key, g => g.Select(x => x)
				.ToArray());

			_logger.LogInformation("End GetLastNewsForMostPopularSymbolsAsync");

			return news;
		}

		public async Task<IEnumerable<NewsDto>> GetIntradayNewsAsync(string symbol, int last = 1)
		{
			_logger.LogInformation("Start GetNewsAsync");

			var response = await _sandBoxClient.News.NewsAsync(symbol, last);

			if (response?.Data.Any() != true)
				return Array.Empty<NewsDto>();

			var newsDtos = _mapper.Map<List<NewsDto>>(response.Data);

			foreach (var news in newsDtos)
			{
				news.Symbol = symbol;
			}

			_logger.LogInformation("End GetNewsAsync");

			return newsDtos;
		}

		public async Task<IEnumerable<NewsDto>> GetHistoricalNewsAsync(string symbol, TimeSeriesRange? timeSeriesRange = null, int? limit = null)
		{
			_logger.LogInformation("Start GetHistoricalNewsAsync");

			var response = await _sandBoxClient.News.HistoricalNewsAsync(symbol, timeSeriesRange, limit);

			if (response?.Data.Any() != true)
				return Array.Empty<NewsDto>();

			var newsDtos = _mapper.Map<List<NewsDto>>(response.Data);

			foreach (var news in newsDtos)
			{
				news.Symbol = symbol;
			}

			_logger.LogInformation("End GetHistoricalNewsAsync");

			return newsDtos;
		}

		public async Task<IEnumerable<NewsDto>> GetNewsStreamAsync(IEnumerable<string> symbols)
		{
			_logger.LogInformation("Start GetNewsStreamAsync");

			var newsResponse = new List<NewsResponse>();

			using var sseClient = _sandBoxClient.News.NewsStream(symbols);
			sseClient.Error += (s, e) =>
			{
				sseClient.Close();
			};
			sseClient.MessageReceived += (s, m) =>
			{
				newsResponse = m.ToList();
				sseClient.Close();
			};
			await sseClient.StartAsync();

			_logger.LogInformation("End GetNewsStreamAsync");

			return _mapper.Map<List<NewsDto>>(newsResponse);
		}
	}
}
