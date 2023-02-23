namespace FinanceProcessor.Core.Models
{
	public class AnalystRecommendationsDto
	{
		public long? ConsensusEndDate { get; set; }
		public long consensusStartDate { get; set; }
		public long? CorporateActionsAppliedDate { get; set; }
		public int? RatingBuy { get; set; }
		public int? RatingOverweight { get; set; }
		public int? RatingHold { get; set; }
		public int? RatingUnderweight { get; set; }
		public int? RatingSell { get; set; }
		public int? RatingNone { get; set; }
		public decimal RatingScaleMark { get; set; }
	}
}
