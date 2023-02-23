namespace FinanceProcessor.Core.Models
{
	public class TechnicalIndicatorsDto
	{
		public IEnumerable<string> Indicator { get; set; }
		public IEnumerable<Dictionary<string, string>> Chart { get; set; }
	}
}