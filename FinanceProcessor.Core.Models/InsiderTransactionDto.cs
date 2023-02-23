namespace FinanceProcessor.Core.Models
{
	public class InsiderTransactionDto
	{
		public decimal? ConversionOrExercisePrice { get; set; }
		public string DirectIndirect { get; set; }
		public long EffectiveDate { get; set; }
		public string FilingDate { get; set; }
		public string FullName { get; set; }
		public bool Is10b51 { get; set; }
		public decimal? PostShares { get; set; }
		public string ReportedTitle { get; set; }
		public string Symbol { get; set; }
		public string TransactionCode { get; set; }
		public string TransactionDate { get; set; }
		public decimal? TransactionPrice { get; set; }
		public decimal? TransactionShares { get; set; }
		public decimal? TransactionValue { get; set; }
		public string Id { get; set; }
		public string Key { get; set; }
		public string Subkey { get; set; }
		public long Date { get; set; }
		public decimal Updated { get; set; }
		public decimal? TranPrice { get; set; }
		public decimal? TranShares { get; set; }
		public decimal? TranValue { get; set; }
	}
}
