using Microsoft.EntityFrameworkCore;

namespace Aimnext.MessageApiWrapper.App.Models.Database;

public class AppDBContext : DbContext
{
    public virtual DbSet<m_userdata> m_userdata { get; set; } = null!;

    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
}