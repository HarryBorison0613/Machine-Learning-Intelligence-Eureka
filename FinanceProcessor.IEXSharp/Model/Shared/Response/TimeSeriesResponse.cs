namespace FinanceProcessor.IEXSharp.Model.Shared.Response
{
	public class TimeSeriesResponse
	{
        public string dataId { get; set; }
        public string date { get; set; }
        public string frequency { get; set; }
        public double value { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string subkey { get; set; }
        public long updated { get; set; }
    }
}