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
	public class SectorJob : IJob
	{
		private IEXCloudClient _sandBoxClient;
		private readonly ILogger<SectorJob> _logger;
		private readonly ISectorRepository _sectorRepository;
		private readonly IMapper _mapper;

		public SectorJob(IDataService ds, ILogger<SectorJob> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper)
		{
			_sectorRepository = ds.Sectors;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);

			_mapper = mapper;
			_logger = logger;
		}

		public async Task Execute(IJobExecutionContext context)
		{
			_logger.LogInformation("Start SectorJob");

			var tasks = new List<Task>();
			try
			{
				var response = await _sandBoxClient.ReferenceData.SectorsAsync();

				if (response?.Data.Any() != true)
					return;

				var sectors = _mapper.Map<List<Sector>>(response.Data);

				foreach (var sector in sectors)
				{
					var task = _sectorRepository.CreateOrReplaceSectorAsync(sector);
					tasks.Add(task);
				}

				var taskToDelete = _sectorRepository.DeleteSectorsIfNeededAsync(sectors);
				tasks.Add(taskToDelete);

				await Task.WhenAll(tasks);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			_logger.LogInformation("End SectorJob");
		}
	}
}
