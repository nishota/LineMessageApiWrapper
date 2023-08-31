using System.Text.Json.Serialization;

namespace Aimnext.MessageApiWrapper.App.Models.ChannelAccessToken;

public class KeyIdList
{
    [JsonPropertyName("kids")]
    public List<string> Kids { get; set; } = null!;
}