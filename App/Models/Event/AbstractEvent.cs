using System.Text.Json.Serialization;

namespace Aimnext.MessageApiWrapper.App.Models.Event;

public abstract class AbstractEvent
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;
    [JsonPropertyName("mode")]
    public string Mode { get; set; } = null!;
    [JsonPropertyName("timestamp")]
    public int TimeStamp { get; set; }
    [JsonPropertyName("source")]
    public Source Source { get; set; } = null!;
    [JsonPropertyName("webhookEventId")]
    public string EventId { get; set; } = null!;
    [JsonPropertyName("deliveryContext")]
    public DeliveryContext Context { get; set; } = null!;
}