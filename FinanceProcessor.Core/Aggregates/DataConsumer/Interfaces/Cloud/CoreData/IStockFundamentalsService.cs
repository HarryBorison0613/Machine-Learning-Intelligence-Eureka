using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.StockFundamentals.Request;
using FinanceProcessor.IEXSharp.Model.Shared.Request;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData
{
	public interface IStockFundamentalsService
	{
		Task<IEnumerable<AdvancedFundamentalsDto>> GetAdvancedFundamentalsAsync(string symbol, TimeSeriesPeriod timeSeriesPeriod, TimeSeries? timeSeries = null, CancellationToken cancellationToken = default);
		Task<BalanceSheetDto> GetBalanceSheetAsync(string symbol, Period period, int last = 1, CancellationToken cancellationToken = default);
		Task<string> GetBalanceSheetFieldAsync(string symbol, string field, Period period = Period.Quarter, int last = 1, CancellationToken cancellationToken = default);
		Task<CashFlowsDto> GetCashFlowAsync(string symbol, Period period = Period.Quarter, int last = 1, CancellationToken cancellationToken = default);
		Task<string> GetCashFlowFieldAsync(string symbol, string field, Period period = Period.Quarter, int last = 1, CancellationToken cancellationToken = default);
		Task<IEnumerable<DividendBasicDto>> GetDividendsBasicAsync(string symbol, DividendRange range, CancellationToken cancellationToken = default);
		Task<EarningDto> GetEarningAsync(string symbol, int last = 1, CancellationToken cancellationToken = default);
		Task<string> GetEarningFieldAsync(string symbol, string field, int last = 1, CancellationToken cancellationToken = default);
		Task<FinancialDto> GetFinancialAsync(string symbol, int last = 1, CancellationToken cancellationToken = default);
		Task<string> GetFinancialFieldAsync(string symbol, string field, int last = 1, CancellationToken cancellationToken = default);
		Task<IncomeStatementDto> GetIncomeStatementAsync(string symbol, Period period = Period.Quarter, int last = 1, CancellationToken cancellationToken = default);
		Task<string> GetIncomeStatementFieldAsync(string symbol, string field, Period period = Period.Quarter, int last = 1, CancellationToken cancellationToken = default);
		Task<IEnumerable<ReportedFinancialDto>> GetReportedFinancialsAsync(string symbol, Filing filing = Filing.Quarterly, TimeSeries? timeSeries = null, CancellationToken cancellationToken = default);
		Task<IEnumerable<SplitBasicDto>> GetSplitsBasicAsync(string symbol, SplitRange range = SplitRange.OneMonth, CancellationToken cancellationToken = default);
		Task<IEnumerable<FundamentalValuationsDto>> GetFundamentalValuationsAsync(string symbol, TimeSeriesPeriod timeSeriesPeriod, TimeSeries? timeSeries = null, CancellationToken cancellationToken = default);
	}
}