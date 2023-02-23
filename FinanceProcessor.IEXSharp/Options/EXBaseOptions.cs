namespace FinanceProcessor.IEXSharp.Options
{
	public abstract class EXBaseOptions
	{
		public string PublishableToken { get; set; }
		public string SecretToken { get; set; }
		public string BasePath { get; set; }
		public string BasePathSSE { get; set; }
	}
}
