using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Helper;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.CoreData.Batch.Request;
using FinanceProcessor.IEXSharp.Model.CoreData.Batch.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.StockPrices.Request;

namespace FinanceProcessor.IEXSharp.Service.Cloud.CoreData.Batch
{
	internal class BatchService : IBatchService
	{
		private readonly ExecutorREST executor;

		internal BatchService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<BatchResponse>>BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types, ChartRange chartRange, int? last = null)
		{
			if (string.IsNullOrEmpty(symbol))
			{
				throw new ArgumentNullException(nameof(symbol));
			}
			else if (types?.Count() < 1)
			{
				throw new ArgumentNullException(nameof(types));
			}

			const string urlPattern = "stock/[symbol]/batch";

			var qsType = new List<string>();
			foreach (var type in types)
			{
				qsType.Add(type.GetDescriptionFromEnum());
			}

			var qsb = new QueryStringBuilder();
			qsb.Add("types", string.Join(",", qsType));

			qsb.Add("range", chartRange);
			if (last != null) 
			{
				qsb.Add("last", last);
			}

			var pathNvc = new NameValueCollection { { "symbol", symbol } };

			return await executor.ExecuteAsync<BatchResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<Dictionary<string, BatchResponse>>> BatchByMarketAsync(IEnumerable<string> symbols, IEnumerable<BatchType> types, ChartRange chartRange, int? last = null)
		{
			if (symbols?.Count() < 1)
			{
				throw new ArgumentNullException("symbols cannot be null");
			}
			else if (types?.Count() < 1)
			{
				throw new ArgumentNullException("batchTypes cannot be null");
			}

			const string urlPattern = "stock/market/batch";

			var qsType = new List<string>();
			foreach (var type in types)
			{
				qsType.Add(type.GetDescriptionFromEnum());
			}

			var qsb = new QueryStringBuilder();
			qsb.Add("symbols", string.Join(",", symbols));
			qsb.Add("types", string.Join(",", qsType));

			qsb.Add("range", chartRange);
			qsb.Add("last", last);

			var pathNvc = new NameValueCollection();

			return await executor.ExecuteAsync<Dictionary<string, BatchResponse>>(urlPattern, pathNvc, qsb);
		}
	}
}