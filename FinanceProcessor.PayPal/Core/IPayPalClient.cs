using HttpClient = PayPalHttp.HttpClient;

namespace FinanceProcessor.PayPal.Core
{
    public interface IPayPalClient
    {
        HttpClient Client();

        HttpClient Client(string refreshToken);
    }
}
