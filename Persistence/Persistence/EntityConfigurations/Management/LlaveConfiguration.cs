using System.IO.Compression;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Persistence.EntityConfiguration.Llave;


public class LlaveConfiguration : IEntityTypeConfiguration<Core.Domain.Management.Llave>
{
    public void Configure(EntityTypeBuilder<Core.Domain.Management.Llave> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .IsRequired();

        builder.ToTable("Llaves");
    }
}