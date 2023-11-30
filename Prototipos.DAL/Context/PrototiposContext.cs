using Microsoft.EntityFrameworkCore;
using Prototipos.DAL.Models;

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

    public DbSet<Usuario> Usuarios {  get; set; }
    public DbSet<Zona> Zonas {  get; set; }
    public DbSet<Mesa> Mesas {  get; set; }
    public DbSet<Reserva> Reservas {  get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
