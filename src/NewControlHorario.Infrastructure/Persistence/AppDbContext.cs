using Microsoft.EntityFrameworkCore;
using NewControlHorario.Domain.Entities;

namespace NewControlHorario.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<TimeEntry> TimeEntries => Set<TimeEntry>();
    public DbSet<OvertimeRequest> OvertimeRequests => Set<OvertimeRequest>();
    public DbSet<Incident> Incidents => Set<Incident>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Email).IsRequired();
            entity.HasMany(x => x.Roles);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Name).IsRequired();
        });

        modelBuilder.Entity<TimeEntry>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Timestamp).IsRequired();
            entity.HasOne(x => x.User)
                  .WithMany()
                  .HasForeignKey(x => x.UserId);
        });

        modelBuilder.Entity<OvertimeRequest>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Reason).HasMaxLength(512);
            entity.HasOne(x => x.User)
                  .WithMany()
                  .HasForeignKey(x => x.UserId);
        });

        modelBuilder.Entity<Incident>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.StartDate).IsRequired();
            entity.HasOne(x => x.User)
                  .WithMany()
                  .HasForeignKey(x => x.UserId);
        });
    }
}
