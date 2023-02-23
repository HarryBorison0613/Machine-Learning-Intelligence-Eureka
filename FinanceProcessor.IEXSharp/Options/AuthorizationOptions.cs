namespace FinanceProcessor.IEXSharp.Options
{
    public class AuthorizationOptions
    {
        public const string SECTION_NAME = "Authorization";

        public string AuthKey { get; set; }
        public string BFFDomain { get; set; }
    }
}
