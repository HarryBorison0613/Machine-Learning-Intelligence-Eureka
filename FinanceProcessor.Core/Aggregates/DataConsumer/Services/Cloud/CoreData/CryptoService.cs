using AutoMapper;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData;
using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp;
using FinanceProcessor.IEXSharp.Model.CoreData.Crypto.Response;
using FinanceProcessor.IEXSharp.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Services.Cloud.CoreData
{
	public class CryptoService : ICryptoService
	{
		private readonly ILogger<CryptoService> _logger;
		private readonly IMapper _mapper;
		private IEXCloudClient _sandBoxClient;

		public CryptoService(ILogger<CryptoService> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper)
		{
			_logger = logger;
			_mapper = mapper;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);
		}

		public async Task<CryptoPriceDto> GetPriceAsync(string symbol)
		{
			_logger.LogInformation("Start PriceAsync");

			var response = await _sandBoxClient.Crypto.PriceAsync(symbol);

			_logger.LogInformation("End PriceAsync");

			return _mapper.Map<CryptoPriceDto>(response.Data);
		}

		public async Task<QuoteCryptoDto> GetQuoteAsync(string symbol)
		{
			_logger.LogInformation("Start QuoteAsync");

			var response = await _sandBoxClient.Crypto.QuoteAsync(symbol);

			_logger.LogInformation("End QuoteAsync");

			return _mapper.Map<QuoteCryptoDto>(response.Data);
		}

		public async Task<CryptoBookDto> BookAsync(string symbol)
		{
			_logger.LogInformation("Start BookAsync");

			var response = await _sandBoxClient.Crypto.BookAsync(symbol);

			_logger.LogInformation("End BookAsync");

			return _mapper.Map<CryptoBookDto>(response.Data);
		}

		public async Task<List<CryptoBookDto>> BookStream(IEnumerable<string> symbols)
		{
			_logger.LogInformation("Start BookStream");

			var cryptoBookResponse = new List<CryptoBookResponse>();

			using var sseClient = _sandBoxClient.Crypto.BookStream(symbols);
			sseClient.Error += (s, e) =>
			{
				sseClient.Close();
			};
			sseClient.MessageReceived += (s, m) =>
			{
				cryptoBookResponse = m.ToList();
				sseClient.Close();
			};
			await sseClient.StartAsync();

			return _mapper.Map<List<CryptoBookDto>>(cryptoBookResponse);
		}

		public async Task<List<EventCryptoDto>> GetEventStream(IEnumerable<string> symbols)
		{
			var eventCryptoResponse = new List<EventCrypto>();

			_logger.LogInformation("Start EventStream");
			using var sseClient = _sandBoxClient.Crypto.EventStream(symbols);
			sseClient.Error += (s, e) =>
			{
				sseClient.Close();
			};
			sseClient.MessageReceived += (s, m) =>
			{
				eventCryptoResponse = m.ToList();
				sseClient.Close();
			};
			await sseClient.StartAsync();

			return _mapper.Map<List<EventCryptoDto>>(eventCryptoResponse);
		}

		public async Task<List<QuoteCryptoDto>> GetQuoteStream(IEnumerable<string> symbols)
		{
			var quoteCryptoResponse = new List<QuoteCryptoResponse>();

			_logger.LogInformation("Start QuoteStream");
			using var sseClient = _sandBoxClient.Crypto.QuoteStream(symbols);
			sseClient.Error += (s, e) =>
			{
				sseClient.Close();
			};
			sseClient.MessageReceived += (s, m) =>
			{
				quoteCryptoResponse = m.ToList();
				sseClient.Close();
			};
			await sseClient.StartAsync();

			return _mapper.Map<List<QuoteCryptoDto>>(quoteCryptoResponse);
		}
	}
}
