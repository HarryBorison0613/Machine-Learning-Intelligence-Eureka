using AutoMapper;
using FinanceProcessor.IEXSharp;
using FinanceProcessor.IEXSharp.Options;
using FinanceProcessor.MongoDB.Contracts.Entities;
using FinanceProcessor.MongoDB.Contracts.Repositories;
using FinanceProcessor.MongoDB.Contracts.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quartz;

namespace FinanceProcessor.ApiConsumer.Jobs.Cloud.CoreData
{
	public class OTCSymbolJob : IJob
	{
		private IEXCloudClient _sandBoxClient;
		private readonly ILogger<OTCSymbolJob> _logger;
		private readonly IOTCSymbolRepository _otcSymbolRepository;
		private readonly IMapper _mapper;

		public OTCSymbolJob(IDataService ds, ILogger<OTCSymbolJob> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper)
		{
			_otcSymbolRepository = ds.OTCSymbols;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);
			_mapper = mapper;

			_logger = logger;
		}

		public async Task Execute(IJobExecutionContext context)
		{
			_logger.LogInformation("Start OTCSymbolJob");

			var tasks = new List<Task>();

			try
			{
				var response = await _sandBoxClient.ReferenceData.SymbolsOTCAsync();

				if (response?.Data.Any() != true)
					return;

				var symbols = _mapper.Map<List<OTCSymbol>>(response.Data);

				foreach (var symbol in symbols)
				{
					var task = _otcSymbolRepository.CreateOrReplaceOTCSymbolAsync(symbol);
					tasks.Add(task);
				}

				var taskToDelete = _otcSymbolRepository.DeleteSymbolsIfNeededAsync(symbols);
				tasks.Add(taskToDelete);

				await Task.WhenAll(tasks);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			_logger.LogInformation("End OTCSymbolJob");
		}
	}
}
