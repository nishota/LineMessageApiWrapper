using System.Text.Json.Serialization;

namespace Aimnext.MessageApiWrapper.App.Models.Message;

public abstract class AbstractMessage
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;
}