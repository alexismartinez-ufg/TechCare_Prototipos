using Microsoft.EntityFrameworkCore;

namespace Prototipos;

public partial class PrototiposContext : DbContext
{
    public PrototiposContext()
    {
    }

    public PrototiposContext(DbContextOptions<PrototiposContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
