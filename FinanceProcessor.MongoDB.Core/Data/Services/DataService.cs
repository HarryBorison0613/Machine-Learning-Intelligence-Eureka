using FinanceProcessor.MongoDB.Contracts.Repositories;
using FinanceProcessor.MongoDB.Contracts.Services;
using FinanceProcessor.MongoDB.Core.Data.Repositories;

namespace FinanceProcessor.MongoDB.Core.Data.Services
{
    public class DataService : IDataService
    {
        private readonly MongoContext _dbContext;

        public DataService(MongoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IIntradayPriceRepository IntradayPrices => new IntradayPriceRepository(_dbContext.Database);
		public ISymbolRepository Symbols => new SymbolRepository(_dbContext.Database);
		public ICryptoSymbolRepository CryptoSymbols => new CryptoSymbolRepository(_dbContext.Database);
		public INewsRepository News => new NewsRepository(_dbContext.Database);
		public IIEXSymbolRepository IEXSymbols => new IEXSymbolRepository(_dbContext.Database);
		public ISectorRepository Sectors => new SectorRepository(_dbContext.Database);
		public ITagRepository Tags => new TagRepository(_dbContext.Database);
		public IForexCurrencyRepository ForexCurrencies => new ForexCurrencyRepository(_dbContext.Database);
		public IForexPairRepository ForexPairs => new ForexPairRepository(_dbContext.Database);
		public IMutualFundsSymbolRepository MutualFundsSymbols => new MutualFundsSymbolRepository(_dbContext.Database);

		public IOTCSymbolRepository OTCSymbols => new OTCSymbolRepository(_dbContext.Database);
		public IExchangeUSRepository ExchangesUS => new ExchangeUSRepository(_dbContext.Database);

		public IInternationalExchangeRepository InternationalExchanges => new InternationalExchangeRepository(_dbContext.Database);
	}
}
