namespace FinanceProcessor.Core.Models
{
	public class EstimatesDto
	{
		public string Symbol { get; set; }
		public List<EstimateDto> Estimates { get; set; }
	}
}