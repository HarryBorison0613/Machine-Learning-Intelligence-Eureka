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
	public class InternationalExchangeJob : IJob
	{
		private IEXCloudClient _sandBoxClient;
		private readonly ILogger<InternationalExchangeJob> _logger;
		private readonly IInternationalExchangeRepository _exchangeUSRepository;
		private readonly IMapper _mapper;

		public InternationalExchangeJob(IDataService ds, ILogger<InternationalExchangeJob> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper)
		{
			_exchangeUSRepository = ds.InternationalExchanges;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);

			_mapper = mapper;
			_logger = logger;
		}

		public async Task Execute(IJobExecutionContext context)
		{
			_logger.LogInformation("Start InternationalExchangeJob");

			var tasks = new List<Task>();
			try
			{
				var response = await _sandBoxClient.ReferenceData.ExchangeInternationalAsync();

				if (response?.Data.Any() != true)
					return;

				var internationalExchanges = _mapper.Map<List<InternationalExchange>>(response.Data);

				foreach (var internationalExchange in internationalExchanges)
				{
					var task = _exchangeUSRepository.CreateOrReplaceInternationalExchangeAsync(internationalExchange);
					tasks.Add(task);
				}

				var taskToDelete = _exchangeUSRepository.DeleteInternationalExchangesIfNeededAsync(internationalExchanges);
				tasks.Add(taskToDelete);

				await Task.WhenAll(tasks);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			_logger.LogInformation("End InternationalExchangeJob");
		}
	}
}
