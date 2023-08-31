using System.ComponentModel.DataAnnotations.Schema;

namespace Aimnext.MessageApiWrapper.App.Models.Database;
[Table("m_userdata")]
public partial class m_userdata
{
    [Column("id")]
    public string Id { get; set; } = null!;
    [Column("messageId")]
    public string MessageId { get; set; } = null!;
    [Column("message")]
    public string Message { get; set; } = null!;
}
