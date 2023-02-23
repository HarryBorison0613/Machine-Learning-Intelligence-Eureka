using Newtonsoft.Json;

namespace FinanceProcessor.PayPalSubscriptions.Models
{
    public record PlanBodyDto
    {
        [JsonProperty("requested_role")]
        public string? RequestedRole { get; init; }

        [JsonProperty("image_url")]
        public string? ImageUrl { get; init; }

        [JsonProperty("home_url")]
        public string? HomeUrl { get; init; }
    }
}
