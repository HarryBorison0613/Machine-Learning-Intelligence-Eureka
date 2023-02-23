using FinanceProcessor.Core.Models;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData
{
	public interface IForexCurrenciesService
	{
		Task<ExchangeRateDto> GetExchangeRateAsync(string fromCurrency, string toCurrency, CancellationToken cancellationToken = default);
		Task<IEnumerable<CurrencyRateDto>> GetLatestRatesAsync(string symbols, CancellationToken cancellationToken = default);
		Task<IEnumerable<CurrencyConvertDto>> ConvertAsync(string symbols, string amount, CancellationToken cancellationToken = default);
		Task<IEnumerable<IEnumerable<CurrencyHistoricalRateDto>>> GetHistoricalDailyAsync(string symbols, string from, string to, int last = 1, CancellationToken cancellationToken = default);
	}
}
