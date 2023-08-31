using System.Text.Json.Serialization;

namespace Aimnext.MessageApiWrapper.App.Models.ChannelAccessToken;

public class AccessTokenInformation
{
    [JsonPropertyName("client_id")]
    public string ClientId { get; set; } = null!;
    [JsonPropertyName("expires_in")]
    public int expires_in { get; set; }
    [JsonPropertyName("scope")]
    public string Scope { get; set; } = null!;
}