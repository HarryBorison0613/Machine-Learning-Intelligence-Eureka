namespace FinanceProcessor.IEXSharp.Options
{
    public class PayPalAuthenticationOptions
    {
        public const string SECTION_NAME = "PayPalAuthentication";

        public string PayPalClientId { get; set; }
        public string PayPalClientSecret { get; set; }
        public string BaseUrl { get; set; } 
        public bool UseSandbox { get; set; }

    }
}
