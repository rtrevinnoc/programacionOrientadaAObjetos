using Core.Domain.Taxonomy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Persistence.EntityConfigurations.Taxonomy
{
    public class SpecieConfiguration : IEntityTypeConfiguration<Specie>
    {
        public void Configure(EntityTypeBuilder<Specie> builder)
        {
            builder.ToTable("Species");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.CommonName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.ScientificName)
                .HasMaxLength(150)
                .IsRequired();
            builder.HasIndex(s => s.ScientificName)
                .IsUnique();


            builder.HasMany(specie => specie.Breeds)
                .WithOne(breed => breed.Specie)
                .HasForeignKey(breed => breed.SpecieId);
        }
    }
}