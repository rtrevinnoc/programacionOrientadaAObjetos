using System;
using Core.Domain.Livestock;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Persistence.EntityConfiguration.Livestock;


public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder.HasKey(c => c.IdRegistration);

        builder.Property(c => c.IdRegistration)
            .IsRequired();

        builder.Property(c => c.ActualRanch)
            .IsRequired();

        builder.Property(c => c.Breed)
            .IsRequired();

        builder.Property(c => c.Species)
            .IsRequired();

        builder.Property(c => c.Gender)
            .IsRequired();

        builder.ToTable("Animals");
    }
}