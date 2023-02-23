using FinanceProcessor.IEXSharp.Options;
using Microsoft.Extensions.Options;

using PayPalCheckoutSdk.Core;

using System.Runtime.Serialization.Json;
using System.Text;

using HttpClient = PayPalHttp.HttpClient;

namespace FinanceProcessor.PayPal.Core
{
    public class PayPalClient : IPayPalClient
    {
        /**
            Setting up PayPal environment with credentials with sandbox cerdentails. 
            For Live, this should be LiveEnvironment Instance. 
         */

        private readonly PayPalAuthenticationOptions _payPalAuthOptions;

        public PayPalClient(IOptions<PayPalAuthenticationOptions> payPalAuthOptions)
        {
            _payPalAuthOptions = payPalAuthOptions.Value;
        }

        public PayPalEnvironment Environment()
        {
            if (_payPalAuthOptions.UseSandbox)
            {
                return new SandboxEnvironment(_payPalAuthOptions.PayPalClientId ?? "<<PAYPAL-CLIENT-ID>>",
                    _payPalAuthOptions.PayPalClientSecret ?? "<<PAYPAL-CLIENT-SECRET>>");
            }
            return new LiveEnvironment(_payPalAuthOptions.PayPalClientId ?? "<<PAYPAL-CLIENT-ID>>",
                    _payPalAuthOptions.PayPalClientSecret ?? "<<PAYPAL-CLIENT-SECRET>>"); ;
        }

        /**
            Returns PayPalHttpClient instance which can be used to invoke PayPal API's.
         */
        public HttpClient Client()
        {
            return new PayPalHttpClient(Environment());
        }

        public HttpClient Client(string refreshToken)
        {
            return new PayPalHttpClient(Environment(), refreshToken);
        }

        /**
            This method can be used to Serialize Object to JSON string.
        */
        public static String ObjectToJSONString(Object serializableObject)
        {
            MemoryStream memoryStream = new();

            var writer = JsonReaderWriterFactory.CreateJsonWriter(
                        memoryStream, Encoding.UTF8, true, true, "  ");

            DataContractJsonSerializer ser = new(
                serializableObject.GetType(),
                new DataContractJsonSerializerSettings
                {
                    UseSimpleDictionaryFormat = true
                });

            ser.WriteObject(writer, serializableObject);
            memoryStream.Position = 0;
            var sr = new StreamReader(memoryStream);
            return sr.ReadToEnd();
        }
    }
}
