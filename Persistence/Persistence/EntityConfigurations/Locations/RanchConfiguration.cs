using Core.Domain.Locations;
using Core.Domain.Livestock;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Persistence.EntityConfigurations.Locations
{
    public class RanchConfiguration : IEntityTypeConfiguration<Ranch>
    {
        public void Configure(EntityTypeBuilder<Ranch> builder)
        {


            builder.ToTable("Ranches");


            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(r => r.Location)
                .HasMaxLength(250);

            builder.HasMany(ranch => ranch.Animals)
                .WithOne(animal => animal.Ranch)
                .HasForeignKey(animal => animal.IdRanch);
        }
    }
}