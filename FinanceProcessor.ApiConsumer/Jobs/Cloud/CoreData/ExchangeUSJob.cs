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
	public class ExchangeUSJob : IJob
	{
		private IEXCloudClient _sandBoxClient;
		private readonly ILogger<ExchangeUSJob> _logger;
		private readonly IExchangeUSRepository _exchangeUSRepository;
		private readonly IMapper _mapper;

		public ExchangeUSJob(IDataService ds, ILogger<ExchangeUSJob> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper)
		{
			_exchangeUSRepository = ds.ExchangesUS;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);

			_mapper = mapper;
			_logger = logger;
		}

		public async Task Execute(IJobExecutionContext context)
		{
			_logger.LogInformation("Start ExchangesUSJob");

			var tasks = new List<Task>();
			try
			{
				var response = await _sandBoxClient.ReferenceData.ExchangeUSAsync();

				if (response?.Data.Any() != true)
					return;

				var exchangesUS = _mapper.Map<List<ExchangeUS>>(response.Data);

				foreach (var exchangeUS in exchangesUS)
				{
					var task = _exchangeUSRepository.CreateOrReplaceExchangeUSAsync(exchangeUS);
					tasks.Add(task);
				}

				var taskToDelete = _exchangeUSRepository.DeleteExchangesUSIfNeededAsync(exchangesUS);
				tasks.Add(taskToDelete);

				await Task.WhenAll(tasks);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			_logger.LogInformation("End ExchangesUSJob");
		}
	}
}
