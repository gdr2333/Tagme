using Microsoft.EntityFrameworkCore;

namespace Tagme.Data;

public class TagContext : DbContext
{
    public DbSet<TagInfo> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=tags.db");
        base.OnConfiguring(optionsBuilder);
    }
}
