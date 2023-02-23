using Newtonsoft.Json;

using PayPalSubscriptionNetSdk.Subscriptions;

namespace FinanceProcessor.PayPalSubscriptions.Models
{
    public record BuildSubscriptionDto
    {
        [JsonProperty("plan_id")]
        public string? PlanId { get; init; }

        [JsonProperty("subscriber")]
        public Subscriber? Subscriber { get; init; }

        [JsonProperty("locale")]
        public string? Locale { get; init; }

        [JsonProperty("return_url")]
        public string? ReturnUrl { get; init; }

        [JsonProperty("cancel_url")]
        public string? CancelUrl { get; init; }
    }
}
