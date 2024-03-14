using Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Magazyn> Magazyny { get; set; }
    public DbSet<Dostawca> Dostawcy { get; set; }
    public DbSet<Towar> Towary { get; set; }
    public DbSet<Etykieta> Etykiety { get; set; }
    public DbSet<DokumentPrzyjecia> DokumentyPrzyjecia { get; set; }
    public DbSet<PozycjaTowaru> PozycjeTowaru { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
