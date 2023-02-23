using FinanceProcessor.MongoDB.Contracts.Entities;

namespace FinanceProcessor.MongoDB.Contracts.Repositories
{
	public interface IIntradayPriceRepository : IRepository<IntradayPrice>
    {
        Task<IEnumerable<IntradayPrice>> GetIntradayPricesBySymbolAsync(string intradayPriceId);

        Task CreateIntradayPriceAsync(IntradayPrice intradayPrice, string cryptoSymbol);

        Task DeleteIntradayPriceAsync(string id);

        Task<bool> IsExist(string cryptoSymbol, string date, string minute);
    }
}
