using Newtonsoft.Json;

using PayPalCheckoutSdk.Orders;

using System.Runtime.Serialization;
using System.Xml.Linq;

namespace FinanceProcessor.PayPal.Models
{
    public record OrderDto
    {
        [DataMember(Name = "application_context", EmitDefaultValue = false)]
        public ApplicationContext? ApplicationContext;

        [JsonProperty("purchase_units")]
        public List<PurchaseUnitRequest>? PurchaseUnits { get; set; }

        [JsonProperty("claimed_role")]
        public string? ClaimedRole { get; set; }
    }
}
