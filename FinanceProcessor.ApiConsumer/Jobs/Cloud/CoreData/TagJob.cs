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
	public class TagJob : IJob
	{
		private IEXCloudClient _sandBoxClient;
		private readonly ILogger<TagJob> _logger;
		private readonly ITagRepository _tagRepository;
		private readonly IMapper _mapper;

		public TagJob(IDataService ds, ILogger<TagJob> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper)
		{
			_tagRepository = ds.Tags;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);

			_mapper = mapper;
			_logger = logger;
		}

		public async Task Execute(IJobExecutionContext context)
		{
			_logger.LogInformation("Start TagJob");

			var tasks = new List<Task>();
			try
			{
				var response = await _sandBoxClient.ReferenceData.TagsAsync();

				if (response?.Data.Any() != true)
					return;

				var tags = _mapper.Map<List<Tag>>(response.Data);

				foreach (var tag in tags)
				{
					var task = _tagRepository.CreateOrReplaceTagAsync(tag);
					tasks.Add(task);
				}

				var taskToDelete = _tagRepository.DeleteTagsIfNeededAsync(tags);
				tasks.Add(taskToDelete);

				await Task.WhenAll(tasks);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			_logger.LogInformation("End TagJob");
		}
	}
}
