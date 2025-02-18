using System.Text.Json.Serialization;

namespace Movies.Contracts.Responses
{
    public abstract class HalResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Link> Links { get; set; } = new();
    }

    public class Link
    {
        public string Href { get; init; }
        public string Rel { get; init; }
        public string Type { get; init; }
    }
}
