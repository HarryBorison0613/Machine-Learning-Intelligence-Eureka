namespace FinanceProcessor.IEXSharp.Options
{
    public sealed class EXCloudClientOptions
    {
        public const string EXCloudClient = "EXCloudClient";
        public bool UseSandbox { get; set; }
        public EXCloudOptions EXCloud { get; set; }
        public SandboxOptions Sandbox { get; set; }
    }
}
