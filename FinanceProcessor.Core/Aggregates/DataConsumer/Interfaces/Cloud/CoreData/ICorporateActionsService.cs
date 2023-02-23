using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.CorporateActions.Request;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData
{
	public interface ICorporateActionsService
	{
		Task<IEnumerable<BonusIssueDto>> GetBonusIssueAsync(string symbol, TimeSeriesRange? range, bool calendar = false, int? last = null, string refId = null, CancellationToken cancellationToken = default);
		Task<IEnumerable<DistributionDto>> GetDistributionAsync(string symbol, TimeSeriesRange? range, bool calendar = false, int? last = null, string refId = null, CancellationToken cancellationToken = default);
		Task<IEnumerable<DividendAdvancedDto>> GetDividendsAdvancedAsync(string symbol, TimeSeriesRange? range, bool calendar, int? last, string refId, CancellationToken cancellationToken = default);
		Task<IEnumerable<ReturnOfCapitalDto>> GetReturnOfCapitalAsync(string symbol, TimeSeriesRange? range, bool calendar = false, int? last = null, string refId = null, CancellationToken cancellationToken = default);
		Task<IEnumerable<RightsIssueDto>> GetRightsIssueAsync(string symbol, TimeSeriesRange? range, bool calendar = false, int? last = null, string refId = null, CancellationToken cancellationToken = default);
		Task<IEnumerable<RightToPurchaseDto>> GetRightToPurchaseAsync(string symbol, TimeSeriesRange? range, bool calendar = false, int? last = null, string refId = null, CancellationToken cancellationToken = default);
		Task<IEnumerable<SecurityUpdateDto>> GetSecurityReclassificationAsync(string symbol, TimeSeriesRange? range, bool calendar, int? last, string refId, CancellationToken cancellationToken = default);
		Task<IEnumerable<SecurityUpdateDto>> GetSecuritySwapAsync(string symbol, TimeSeriesRange? range, bool calendar, int? last, string refId, CancellationToken cancellationToken = default);
		Task<IEnumerable<SpinOffDto>> GetSpinOffAsync(string symbol, TimeSeriesRange? range, bool calendar, int? last, string refId, CancellationToken cancellationToken = default);
		Task<IEnumerable<SplitAdvancedDto>> GetSplitsAdvancedAsync(string symbol, TimeSeriesRange? range, bool calendar, int? last, string refId, CancellationToken cancellationToken = default);

		Task<IEnumerable<DividendForecastDto>> GetDividendsForecastAsync(string symbol, CancellationToken cancellationToken = default);
	}
}