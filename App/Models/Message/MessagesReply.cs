using System.Text.Json.Serialization;

namespace Aimnext.MessageApiWrapper.App.Models.Message;

public class MessagesReply : Messages
{
    [JsonPropertyName("replyToken")]
    public string ReplyToken { get; set; } = null!;
}