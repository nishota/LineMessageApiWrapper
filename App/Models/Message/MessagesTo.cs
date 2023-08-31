using System.Text.Json.Serialization;

namespace Aimnext.MessageApiWrapper.App.Models.Message;

public class MessagesTo : Messages
{
    [JsonPropertyName("to")]
    public string To { get; set; } = null!;
}