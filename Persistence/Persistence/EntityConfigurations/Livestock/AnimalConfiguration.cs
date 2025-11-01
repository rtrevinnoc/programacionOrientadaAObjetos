// En: Persistence/Persistence/EntityConfigurations/Livestock/AnimalConfiguration.cs
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

        builder.Property(c => c.IdRanch)
            .IsRequired();

        builder.Property(c => c.IdBreed)
            .IsRequired(false);

        builder.Property(c => c.IdSpecie)
            .IsRequired();

        builder.Property(c => c.Gender)
            .IsRequired();


        builder.HasOne(a => a.Ranch)
            .WithMany(r => r.Animals)
            .HasForeignKey(a => a.IdRanch)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Specie)
            .WithMany(s => s.Animals)
            .HasForeignKey(a => a.IdSpecie)
            .OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(a => a.Breed)
            .WithMany()
            .HasForeignKey(a => a.IdBreed)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("Animals");
    }
}