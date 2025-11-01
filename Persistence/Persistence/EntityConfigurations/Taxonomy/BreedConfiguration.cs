using Core.Domain.Taxonomy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Persistence.EntityConfigurations.Taxonomy
{
    public class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);


            builder.HasOne(b => b.Specie)
                .WithMany(s => s.Breeds)
                .HasForeignKey(b => b.SpecieId)
                .OnDelete(DeleteBehavior.Cascade);
                
            builder.ToTable("Breeds");
        }
    }
}