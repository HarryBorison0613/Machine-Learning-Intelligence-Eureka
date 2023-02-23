namespace FinanceProcessor.Core.Models
{
	public class IPOCalendarDto
    {
        public decimal? CurrentPrice { get; set; }
        public string FiledDate { get; set; }
        public decimal? FirstDayClose { get; set; }
        public string Status { get; set; }
        public string CompanyName { get; set; }
        public string LockupPeriod { get; set; }
        public string Managers { get; set; }
        public string OfferingDate { get; set; }
        public decimal? OfferPrice { get; set; }
        public decimal? PriceRangeHigh { get; set; }
        public decimal? PriceRangeLow { get; set; }
        public string Quietperiod { get; set; }
        public decimal? ReturnValue { get; set; }
        public int Shares { get; set; }
        public string Symbol { get; set; }
        public string Updated { get; set; }
        public int Volume { get; set; }
    }
}
