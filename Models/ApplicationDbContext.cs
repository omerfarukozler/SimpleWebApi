using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Ogrenci> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ogrenci>(entity =>
        {
            entity.ToTable("Students");
        });
    }
}
