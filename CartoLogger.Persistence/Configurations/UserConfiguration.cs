using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CartoLogger.Domain.Entities;
using CartoLogger.Domain.Constraints;

namespace CartoLogger.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> modelBuilder)
    {
        modelBuilder.HasKey(user => user.Id);
        modelBuilder.Property(user => user.Id)
             .ValueGeneratedOnAdd();

        modelBuilder.Property(user => user.Name)
             .IsRequired()
             .HasMaxLength(User.NameConstraints.maxLength);

        modelBuilder.HasIndex(user => user.Name)
             .IsUnique();


        modelBuilder.Property(user => user.Email)
             .IsRequired()
             .HasMaxLength(EmailConstaints.maxLength);

        modelBuilder.HasIndex(user => user.Email)
             .IsUnique();

    }
}
