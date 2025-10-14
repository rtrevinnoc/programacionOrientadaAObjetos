using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CartoLogger.Domain.Entities;
using CartoLogger.Domain.Constraints;

namespace CartoLogger.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> table)
    {
        table.HasKey(user => user.Id);
        table.Property(user => user.Id)
             .ValueGeneratedOnAdd();

        table.Property(user => user.Name)
             .IsRequired()
             .HasMaxLength(User.NameConstraints.maxLength);
        table.HasIndex(user => user.Name)
             .IsUnique();

        table.Property(user => user.Email)
             .IsRequired()
             .HasMaxLength(EmailConstaints.maxLength);
        table.HasIndex(user => user.Email)
             .IsUnique();  
    }
}
