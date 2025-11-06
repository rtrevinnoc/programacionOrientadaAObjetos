using Core.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Persistence.EntityConfigurations.Locations
{
    public class CorralConfiguration : IEntityTypeConfiguration<Corral>
    {
        public void Configure(EntityTypeBuilder<Corral> builder)
        {
            builder.HasKey(c => c.IdCorral);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Capacity)
                .IsRequired();

            builder.HasMany(c => c.Animals)
                .WithOne(a => a.Corral)
                .HasForeignKey(a => a.CorralId);
        }
    }
}