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
	public class IEXSymbolJob : IJob
	{
		private IEXCloudClient _sandBoxClient;
		private readonly ILogger<SymbolJob> _logger;
		private readonly IIEXSymbolRepository _iEXsymbolRepository;
		private readonly IMapper _mapper;

		public IEXSymbolJob(IDataService ds, ILogger<SymbolJob> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper)
		{
			_iEXsymbolRepository = ds.IEXSymbols;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);

			_mapper = mapper;
			_logger = logger;
		}

		public async Task Execute(IJobExecutionContext context)
		{
			_logger.LogInformation("Start IEXSymbolJob");

			var tasks = new List<Task>();

			try
			{
				var response = await _sandBoxClient.ReferenceData.SymbolsIEXAsync();

				if (response?.Data.Any() != true)
					return;

				var symbols = _mapper.Map<List<IEXSymbol>>(response.Data);

				foreach (var symbol in symbols)
				{
					var task = _iEXsymbolRepository.CreateOrReplaceIEXSymbolAsync(symbol);
					tasks.Add(task);
				}

				var taskToDelete = _iEXsymbolRepository.DeleteSymbolsIfNeededAsync(symbols);
				tasks.Add(taskToDelete);

				await Task.WhenAll(tasks);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			_logger.LogInformation("End IEXSymbolJob");
		}
	}
}
