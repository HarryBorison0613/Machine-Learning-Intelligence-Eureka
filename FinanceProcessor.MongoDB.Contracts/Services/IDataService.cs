using FinanceProcessor.MongoDB.Contracts.Repositories;

namespace FinanceProcessor.MongoDB.Contracts.Services
{
    public interface IDataService
    {
        public IIntradayPriceRepository IntradayPrices { get; }
        public ISymbolRepository Symbols { get; }
        public INewsRepository News { get; }
        public ICryptoSymbolRepository CryptoSymbols { get; }
        public IIEXSymbolRepository IEXSymbols { get; }
        public ISectorRepository Sectors { get; }
        public ITagRepository Tags { get; }
        public IForexCurrencyRepository ForexCurrencies { get; }
        public IForexPairRepository ForexPairs { get; }
        public IMutualFundsSymbolRepository MutualFundsSymbols { get; }
        public IOTCSymbolRepository OTCSymbols { get; }
        public IExchangeUSRepository ExchangesUS { get; }
        public IInternationalExchangeRepository InternationalExchanges { get; }
    }
}
