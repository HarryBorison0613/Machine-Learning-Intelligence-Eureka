using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Helper;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.PremiumData.AuditAnalytics.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.PremiumData.AuditAnalytics
{
	public class AuditAnalyticsService : IAuditAnalyticsService
	{
		private readonly ExecutorREST executor;

		internal AuditAnalyticsService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<IEnumerable<DirectorAndOfficerChangesResponse>>> DirectorAndOfficerChangesAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<DirectorAndOfficerChangesResponse>>($"time-series/PREMIUM_AUDIT_ANALYTICS_DIRECTOR_OFFICER_CHANGES/{symbol}");

		public async Task<IEXResponse<IEnumerable<AccountingQualityAndRiskMatrixResponse>>> AccountingQualityAndRiskMatrixAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<AccountingQualityAndRiskMatrixResponse>>($"time-series/PREMIUM_AUDIT_ANALYTICS_ACCOUNTING_QUALITY_RISK_MATRIX/{symbol}");
	}
}