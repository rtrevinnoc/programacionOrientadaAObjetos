using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CartoLogger.Domain.Entities;

namespace CartoLogger.Persistence.Configurations;

public class MapConfiguration : IEntityTypeConfiguration<Map>
{
    public void Configure(EntityTypeBuilder<Map> modelBuilder)
    {
        modelBuilder.HasKey(map => map.Id);
        modelBuilder.Property(map => map.Id)
             .ValueGeneratedOnAdd();

        modelBuilder.Property(map => map.Title)
             .IsRequired()
             .HasMaxLength(Map.TitleConstraints.maxLength);

        modelBuilder.Property(map => map.Description)
             .IsRequired()
             .HasMaxLength(Map.DescriptionConstraints.maxLength);

        modelBuilder.OwnsOne(map => map.View, view =>
        {
            view.OwnsOne(v => v.Center, center =>
            {
                center.Property(c => c.Lat)
                      .HasColumnName("ViewCenterLat")
                      .IsRequired();

                center.Property(c => c.Lng)
                      .HasColumnName("ViewCenterLng")
                      .IsRequired();
            });
            
            view.Property(v => v.Zoom)
                .HasColumnName("ViewZoom")
                .IsRequired();
        });

        modelBuilder.HasOne(map => map.User)
             .WithMany(user => user.Maps)
             .HasForeignKey(map => map.UserId)
             .OnDelete(DeleteBehavior.SetNull);

    }
}
