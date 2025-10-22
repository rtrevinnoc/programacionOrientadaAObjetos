using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Persistence.EntityConfiguration.Classroom;


public class ClassroomConfiguration : IEntityTypeConfiguration<Core.Domain.Management.Classroom>
{
    public void Configure(EntityTypeBuilder<Core.Domain.Management.Classroom> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .IsRequired();

        builder.HasMany(c => c.Schedules)
            .WithOne(c => c.Classroom)
            .HasForeignKey(c => c.ClassroomId);

        builder.HasOne(e => e.Llave)
            .WithOne(e => e.Classroom)
            .HasForeignKey<Core.Domain.Management.Llave>(e => e.ClassroomId)
            .IsRequired();

        builder.ToTable("Classrooms");
    }
}