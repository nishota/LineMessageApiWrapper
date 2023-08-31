using System.Text.Json.Serialization;

namespace Aimnext.MessageApiWrapper.App.Models.Message;

public class Messages
{
    [JsonPropertyName("messages")]
    public List<TextData> Texts { get; set; } = null!;

    public void Add(TextData message)
    {
        if(Texts is not null)
        {
            Texts.Add(message);
        }
    }
}