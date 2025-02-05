using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Ogrenci> Students { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("server=loopback.host;port=9900;database=omer;user=omer;pwd=galatasaray.omer;SslMode=none;AllowPublicKeyRetrieval=True;",
                new MySqlServerVersion(new Version(8, 0, 33)),
                options =>
                {
                    options.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null);
                });
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Ogrenci>(entity =>
        {
            entity.ToTable("Students");
        });
    }

}
