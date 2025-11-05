using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CartoLogger.Domain.Entities;

namespace CartoLogger.Persistence.Configurations;

public class UserFavoriteMapConfiguration : IEntityTypeConfiguration<UserFavoriteMap>
{
    public void Configure(EntityTypeBuilder<UserFavoriteMap> modelBuilder)
    {
        modelBuilder.HasKey(ufm => new {ufm.UserId, ufm.MapId});

        modelBuilder.HasOne(ufm => ufm.User)
                    .WithMany(user => user.FavoriteMaps)
                    .HasForeignKey(ufm => ufm.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.HasOne(ufm => ufm.Map)
                    .WithMany(map => map.FavoritedBy)
                    .HasForeignKey(ufm => ufm.MapId)
                    .OnDelete(DeleteBehavior.Cascade);
    }
}
