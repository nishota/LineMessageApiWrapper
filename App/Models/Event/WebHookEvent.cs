using System.Text.Json.Serialization;

namespace Aimnext.MessageApiWrapper.App.Models.Event;

public class WebHookEvent
{
    [JsonPropertyName("destination")]
    public string Destination { get; set; } = null!;
    [JsonPropertyName("events")]
    public List<MessageEvent> Events { get; set; } = null!;
}