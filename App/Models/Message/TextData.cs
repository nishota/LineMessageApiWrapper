using System.Text.Json.Serialization;

namespace Aimnext.MessageApiWrapper.App.Models.Message;

public class TextData : AbstractMessage
{
    [JsonPropertyName("text")]
    public string Text { get; set; } = null!;

    public TextData()
    {
        Type = "text";
    }
}