
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CartoLogger.Domain.Entities;

namespace CartoLogger.Persistence.Configurations;

public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
{
    public void Configure(EntityTypeBuilder<Feature> table)
    {
        table.HasKey(feature => feature.Id);
        table.Property(feature => feature.Id)
             .ValueGeneratedOnAdd();

        table.Property(feature => feature.Data)
             .IsRequired();

        table.HasOne(feature => feature.User)
             .WithMany(user => user.Features)
             .HasForeignKey(feature => feature.UserId)
             .OnDelete(DeleteBehavior.SetNull);

        table.HasOne(feature => feature.Map)
             .WithMany(user => user.Features)
             .HasForeignKey(feature => feature.MapId)
             .OnDelete(DeleteBehavior.SetNull);
    }
}
