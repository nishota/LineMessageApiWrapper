using System.Text.Json.Serialization;

namespace Aimnext.MessageApiWrapper.App.Models.Event;

public class DeliveryContext
{
    [JsonPropertyName("isRedelivery")]
    public bool IsRedelivery { get; set; }
}