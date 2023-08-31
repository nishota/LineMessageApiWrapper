using System.Text.Json.Serialization;

namespace Aimnext.MessageApiWrapper.App.Models.Event;

public class Source
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;
    [JsonPropertyName("groupId")]
    public string GroupId { get; set; } = null!;
    [JsonPropertyName("userId")]
    public string UserId { get; set; } = null!;
    [JsonPropertyName("roomId")]
    public string RoomId { get; set; } = null!;
}