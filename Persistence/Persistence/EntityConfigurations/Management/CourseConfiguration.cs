using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Persistence.EntityConfiguration.Course;


public class CourseConfiguration : IEntityTypeConfiguration<Core.Domain.Management.Course>
{
    public void Configure(EntityTypeBuilder<Core.Domain.Management.Course> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .IsRequired();

        builder.HasMany(c => c.Schedules)
            .WithOne(c => c.Course)
            .HasForeignKey(c => c.CourseId);

        builder.ToTable("Courses");
    }
}