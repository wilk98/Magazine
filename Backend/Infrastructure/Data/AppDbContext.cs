using Core;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Magazyn> Magazyny { get; set; }
    public DbSet<Dostawca> Dostawcy { get; set; }
    public DbSet<Towar> Towary { get; set; }
    public DbSet<Etykieta> Etykiety { get; set; }
    public DbSet<DokumentPrzyjecia> DokumentyPrzyjecia { get; set; }
    public DbSet<PozycjaTowaru> PozycjeTowaru { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
