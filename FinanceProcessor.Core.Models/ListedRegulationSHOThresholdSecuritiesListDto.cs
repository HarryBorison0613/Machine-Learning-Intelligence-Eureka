namespace FinanceProcessor.Core.Models
{
	public class ListedRegulationSHOThresholdSecuritiesListDto
	{
		public DateTime TradeDate { get; set; }
		public string SymbolinINETSymbology { get; set; }
		public string SymbolinCQSSymbology { get; set; }
		public string SymbolinCMSSymbology { get; set; }
		public string SecurityName { get; set; }
	}
}
