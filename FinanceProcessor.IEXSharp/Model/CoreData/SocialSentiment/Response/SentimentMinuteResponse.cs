using FinanceProcessor.IEXSharp.Helper;

namespace FinanceProcessor.IEXSharp.Model.CoreData.SocialSentiment.Response
{
	public class SentimentMinuteResponse : SentimentResponse, ITimestampedMinute
	{
		public string minute { get; set; }
	}
}
