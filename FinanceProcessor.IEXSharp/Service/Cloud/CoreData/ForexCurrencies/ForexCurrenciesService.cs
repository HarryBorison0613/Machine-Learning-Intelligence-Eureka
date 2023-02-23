using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Helper;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.CoreData.ForexCurrencies.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.CoreData.ForexCurrencies
{
	internal class ForexCurrenciesService : IForexCurrenciesService
	{
		private readonly ExecutorREST executor;

		internal ForexCurrenciesService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<IEnumerable<CurrencyRateResponse>>> LatestRatesAsync(string symbols)
		{
			var nvc = new NameValueCollection();
			var qsb = new QueryStringBuilder();
			qsb.Add("symbols", symbols);

			return await executor.ExecuteAsync<IEnumerable<CurrencyRateResponse>>("fx/latest", nvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<CurrencyConvertResponse>>> ConvertAsync(string symbols, string amount)
		{
			var nvc = new NameValueCollection();
			var qsb = new QueryStringBuilder();
			qsb.Add("symbols", symbols);
			qsb.Add("amount", amount);

			return await executor.ExecuteAsync<IEnumerable<CurrencyConvertResponse>>("fx/convert", nvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<IEnumerable<CurrencyHistoricalRateResponse>>>> HistoricalDailyAsync(string symbols, string from, string to, int last)
		{
			var nvc = new NameValueCollection();
			var qsb = new QueryStringBuilder();
			qsb.Add("symbols", symbols);
			qsb.Add("last", last);
			qsb.Add("from", from);
			qsb.Add("to", to);

			return await executor.ExecuteAsync<IEnumerable<IEnumerable<CurrencyHistoricalRateResponse>>>("fx/historical", nvc, qsb);
		}

		public async Task<IEXResponse<ExchangeRateResponse>> ExchangeRateAsync(string fromCurrency, string toCurrency)
		{
			var qsb = new QueryStringBuilder();
			var pathNvc = new NameValueCollection { { "from", fromCurrency }, { "to", toCurrency } };

			return await executor.ExecuteAsync<ExchangeRateResponse>("fx/rate/[from]/[to]", pathNvc, qsb);
		}
	}
}