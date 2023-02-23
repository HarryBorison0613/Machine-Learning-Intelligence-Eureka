using Newtonsoft.Json;

namespace FinanceProcessor.Core.Aggregates.Customer.DTOs
{
    public class CreateProfile
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string? FirstName { get; init; }

        [JsonProperty(PropertyName = "email")]
        public string? Email { get; init; }

        [JsonProperty(PropertyName = "lastName")]
        public string? LastName { get; init; }

        [JsonProperty(PropertyName = "address")]
        public string? Address { get; init; }

        [JsonProperty(PropertyName = "aptSuite")]
        public string? AptSuite { get; init; }

        [JsonProperty(PropertyName = "city")]
        public string? City { get; init; }

        [JsonProperty(PropertyName = "country")]
        public string? Country { get; init; }

        [JsonProperty(PropertyName = "postalCode")]
        public string? PostalCode { get; init; }

        [JsonProperty(PropertyName = "aboutMe")]
        public string? AboutMe { get; init; }

        [JsonProperty(PropertyName = "admin_area_1")]
        public string? AdminAria { get; init; }

        [JsonProperty(PropertyName = "regionCode")]
        public string? RegionCode { get; init; }
    }
}
