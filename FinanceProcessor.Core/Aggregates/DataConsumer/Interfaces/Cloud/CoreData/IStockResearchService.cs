using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.StockPrices.Request;
using FinanceProcessor.IEXSharp.Model.CoreData.StockResearch.Request;
using FinanceProcessor.IEXSharp.Model.Shared.Request;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData
{
	public interface IStockResearchService
	{
		Task<AdvancedStatsDto> GetAdvancedStatsAsync(string symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<AnalystRecommendationsDto>> GetAnalystRecommendationsAsync(string symbol, CancellationToken cancellationToken = default);
		Task<string> GetEstimateFieldAsync(string symbol, string field, Period period = Period.Quarter, int last = 1, CancellationToken cancellationToken = default);
		Task<EstimatesDto> GetEstimatesAsync(string symbol, Period period = Period.Quarter, int last = 1, CancellationToken cancellationToken = default);
		Task<IEnumerable<FundOwnershipDto>> GetFundOwnershipAsync(string symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<InstitutionalOwnershipDto>> GetInstitutionalOwnerShipAsync(string symbol, CancellationToken cancellationToken = default);
		Task<KeyStatsDto> GetKeyStatsAsync(string symbol, CancellationToken cancellationToken = default);
		Task<string> GetKeyStatsStatAsync(string symbol, string stat, CancellationToken cancellationToken = default);
		Task<PriceTargetDto> GetPriceTargetAsync(string symbol, CancellationToken cancellationToken = default);
		Task<TechnicalIndicatorsDto> GetTechnicalIndicatorsAsync(string symbol, IndicatorName indicatorName, ChartRange range, bool lastIndicator = false, bool indicatorOnly = false, CancellationToken cancellationToken = default);
		Task<RelevantStocksDto> GetRelevantStocksAsync(string symbol, CancellationToken cancellationToken = default);
	}
}