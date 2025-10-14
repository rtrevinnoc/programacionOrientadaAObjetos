using Microsoft.EntityFrameworkCore;

using CartoLogger.Domain.Entities;

namespace CartoLogger.Persistence;

public class CartoLoggerDbContext(DbContextOptions<CartoLoggerDbContext> options)
    : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Map> Maps => Set<Map>();
    public DbSet<Feature> Features => Set<Feature>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        base.OnModelCreating(modelBuilder);
        //applies the configurations of all types inheriting from
        //IEntityTypeConfiguration<T> automatically by looking at the compiled code
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(CartoLoggerDbContext).Assembly
        );
    }
}
