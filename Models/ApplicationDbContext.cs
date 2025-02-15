using Microsoft.EntityFrameworkCore;
using SimpleWebApi;
using SimpleWebApi.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Student>()
        .HasOne(s => s.StudentAddress)
        .WithOne(a => a.Student)
        .HasForeignKey<StudentAddress>(a => a.StudentId);

    modelBuilder.Entity<PhoneNumber>()
    .HasOne(s=>s.Student)
    .WithMany(p=>p.PhoneNumbers);
}

}
