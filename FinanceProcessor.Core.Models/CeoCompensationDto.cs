namespace FinanceProcessor.Core.Models
{
	public class CeoCompensationDto
	{
		public string Symbol { get; set; }
		public string Name { get; set; }
		public string CompanyName { get; set; }
		public string Location { get; set; }
		public decimal Salary { get; set; }
		public decimal Bonus { get; set; }
		public decimal StockAwards { get; set; }
		public decimal OptionAwards { get; set; }
		public decimal NonEquityIncentives { get; set; }
		public decimal PensionAndDeferred { get; set; }
		public decimal OtherComp { get; set; }
		public decimal Total { get; set; }
		public string Year { get; set; }
	}
}
