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
	public class MutualFundsSymbolJob : IJob
	{
		private IEXCloudClient _sandBoxClient;
		private readonly ILogger<MutualFundsSymbolJob> _logger;
		private readonly IMutualFundsSymbolRepository _mutualFundsSymbolRepository;
		private readonly IMapper _mapper;

		public MutualFundsSymbolJob(IDataService ds, ILogger<MutualFundsSymbolJob> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper)
		{
			_mutualFundsSymbolRepository = ds.MutualFundsSymbols;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);
			_mapper = mapper;

			_logger = logger;
		}

		public async Task Execute(IJobExecutionContext context)
		{
			_logger.LogInformation("Start MutualFundsSymbolJob");

			var tasks = new List<Task>();

			try
			{
				var response = await _sandBoxClient.ReferenceData.SymbolsMutualFundAsync();

				if (response?.Data.Any() != true)
					return;

				var symbols = _mapper.Map<List<MutualFundsSymbol>>(response.Data);

				foreach (var symbol in symbols)
				{
					var task = _mutualFundsSymbolRepository.CreateOrReplaceMutualFundsSymbolAsync(symbol);
					tasks.Add(task);
				}

				var taskToDelete = _mutualFundsSymbolRepository.DeleteSymbolsIfNeededAsync(symbols);
				tasks.Add(taskToDelete);

				await Task.WhenAll(tasks);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			_logger.LogInformation("End MutualFundsSymbolJob");
		}
	}
}
