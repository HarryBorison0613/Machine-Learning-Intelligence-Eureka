namespace FinanceProcessor.Core.Models
{
	public class TimeSeriesDto
	{
        public string DataId { get; set; }
        public string Date { get; set; }
        public string Frequency { get; set; }
        public double Value { get; set; }
        public string Id { get; set; }
        public string Key { get; set; }
        public string Subkey { get; set; }
        public long Updated { get; set; }
    }
}
