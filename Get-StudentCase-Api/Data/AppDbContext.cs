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

            entity.Property(e => e.EventId)
                .IsRequired();

            entity.Property(e => e.OccurredUtc)
                .IsRequired();

            entity.Property(e => e.RecordedUtc)
                .IsRequired();

            entity.Property(e => e.StudentId)
                .IsRequired();

            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(e => e.Name)
                .HasMaxLength(100);

            entity.Property(e => e.BirthDate);

            entity.Property(e => e.City)
                .HasMaxLength(100);

            entity.Property(e => e.Course)
                .HasMaxLength(100);

            entity.Property(e => e.Year);

            entity.Property(e => e.Semester);

            entity.Property(e => e.Reason)
                .HasMaxLength(250);
            
        });
    }
}