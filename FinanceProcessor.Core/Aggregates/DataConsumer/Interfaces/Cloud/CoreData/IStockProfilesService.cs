using FinanceProcessor.Core.Models;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData
{
	public interface IStockProfilesService
	{
		Task<CompanyDto> GetCompanyAsync(string symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<InsiderRosterDto>> GetInsiderRosterAsync(string symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<InsiderSummaryDto>> GetInsiderSummaryAsync(string symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<InsiderTransactionDto>> GetInsiderTransactionsAsync(string symbol, CancellationToken cancellationToken = default);
		Task<LogoDto> GetLogoAsync(string symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<string>> GetPeerGroupsAsync(string symbol, CancellationToken cancellationToken = default);
	}
}
