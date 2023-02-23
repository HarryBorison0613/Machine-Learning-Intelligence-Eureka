namespace FinanceProcessor.Core.Aggregates.DataConsumer.Loaders
{
	public class RequestUpdateDateTimeInfo
	{
		public string RequestId { get; set; }

		public DayOfWeek[] DaysOfWeek { get; set; }

		public string[] UpdateTimeAtList { get; set; }
	}
}
