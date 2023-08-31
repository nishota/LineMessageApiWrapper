using System.Text.Json.Serialization;
using Aimnext.MessageApiWrapper.App.Models.Message;

namespace Aimnext.MessageApiWrapper.App.Models.Event;

public class MessageEvent : AbstractEvent
{
    [JsonPropertyName("replyToken")]
    public string ReplyToken { get; set; } = null!;
    [JsonPropertyName("message")]
    public TextData Message { get; set; } = null!;
}