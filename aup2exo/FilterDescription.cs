using System.Text.Json.Serialization;

namespace aup2exo
{
    public class FilterDescription
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("trackbars")]
        public List<string?> Trackbars { get; set; } = new List<string?>();

        [JsonPropertyName("checkboxes")]
        public List<string?> Checkboxes { get; set; } = new List<string?>();
    }
}
