using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.CorporateActions.Request;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData
{
	public interface INewsService
	{
		Task<Dictionary<string, NewsDto[]>> GetLastNewsForMostPopularSymbolsAsync();
		Task<IEnumerable<NewsDto>> GetIntradayNewsAsync(string symbol, int last = 1);
		Task<IEnumerable<NewsDto>> GetHistoricalNewsAsync(string symbol, TimeSeriesRange? timeSeriesRange = null, int? limit = null);
		Task<IEnumerable<NewsDto>> GetNewsStreamAsync(IEnumerable<string> symbols);
	}
}
