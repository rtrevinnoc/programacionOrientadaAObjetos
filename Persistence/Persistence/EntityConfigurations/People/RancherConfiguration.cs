using Core.Domain.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Persistence.EntityConfigurations.People
{
    public class RancherConfiguration : IEntityTypeConfiguration<Rancher>
    {
        public void Configure(EntityTypeBuilder<Rancher> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name).IsRequired().HasMaxLength(100);

            builder.Property(r => r.Username).IsRequired().HasMaxLength(50);
            builder.HasIndex(r => r.Username).IsUnique();

            builder.Property(r => r.PasswordHash).IsRequired();
        }
    }
}