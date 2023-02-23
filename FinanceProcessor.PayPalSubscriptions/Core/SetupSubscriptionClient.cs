using FinanceProcessor.IEXSharp.Options;

using Microsoft.Extensions.Options;

using PayPalSubscriptionNetSdk;

namespace FinanceProcessor.PayPalSubscriptions.Core
{
    public class SetupSubscriptionClient : ISetupSubscriptionClient
    {
        private readonly PayPalAuthenticationOptions _payPalAuthOptions;
        public SetupSubscriptionClient(IOptions<PayPalAuthenticationOptions> payPalAuthOptions)
        {
            _payPalAuthOptions = payPalAuthOptions.Value;
        }

        public void Client()
        {
            RestClientV1.ClientId = _payPalAuthOptions.PayPalClientId;
            RestClientV1.Secret = _payPalAuthOptions.PayPalClientSecret;
            RestClientV1.BaseUrl = _payPalAuthOptions.BaseUrl;
        }
    }
}
