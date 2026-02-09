using Get_StudentCase.Entities;
using Microsoft.EntityFrameworkCore;

namespace Get_StudentCase.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Event> Events => Set<Event>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId);

            entity.Property(e => e.Course)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsRequired();
        });
    }
}