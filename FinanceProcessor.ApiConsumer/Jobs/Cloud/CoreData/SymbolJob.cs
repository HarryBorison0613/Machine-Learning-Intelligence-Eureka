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
	public class SymbolJob : IJob
	{
		private IEXCloudClient _sandBoxClient;
		private readonly ILogger<SymbolJob> _logger;
		private readonly ISymbolRepository _symbolRepository;
		private readonly IMapper _mapper;

		public SymbolJob(IDataService ds, ILogger<SymbolJob> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper)
		{
			_symbolRepository = ds.Symbols;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);

			_mapper = mapper;
			_logger = logger;
		}

		public async Task Execute(IJobExecutionContext context)
		{
			_logger.LogInformation("Start SymbolJob");

			var tasks = new List<Task>();
			try
			{
				var response = await _sandBoxClient.ReferenceData.SymbolsAsync();

				if (response?.Data.Any() != true)
					return;

				var symbols = _mapper.Map<List<Symbol>>(response.Data);

				foreach (var symbol in symbols)
				{
					var task = _symbolRepository.CreateOrReplaceSymbolAsync(symbol);
					tasks.Add(task);
				}

				var taskToDelete = _symbolRepository.DeleteSymbolsIfNeededAsync(symbols);
				tasks.Add(taskToDelete);

				await Task.WhenAll(tasks);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			_logger.LogInformation("End SymbolJob");
		}
	}
}
