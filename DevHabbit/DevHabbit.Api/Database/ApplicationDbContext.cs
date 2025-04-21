using DevHabbit.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevHabbit.Api.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): DbContext(options)
{
    public DbSet<Habbit> Habbits { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<HabbitTag> HabbitTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Application);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}