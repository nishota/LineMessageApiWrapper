using System.Text.Json.Serialization;

namespace Aimnext.MessageApiWrapper.App.Models.ChannelAccessToken;
public class AccessToken
{
    [JsonPropertyName("access_token")]
    public string Token { get; set; } = null!;
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; } = null!;
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
    [JsonPropertyName("key_id")]
    public string KeyId { get; set; } = null!;
}