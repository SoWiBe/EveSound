using System.Text.Json.Serialization;

namespace Common.Models;

public class Music
{
    [JsonPropertyName("id")] public string Id { get; set; }
    [JsonPropertyName("title")] public string Title { get; set; }
    [JsonPropertyName("author")] public string Author { get; set; }
    [JsonPropertyName("description")] public string Description { get; set; }
    [JsonPropertyName("isPlayed")] public bool IsPlayed { get; set; }
    [JsonPropertyName("time")] public long Time { get; set; }
}