using System;
using Core.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Persistence.EntityConfiguration.Schedule;


public class ScheduleConfiguration : IEntityTypeConfiguration<Core.Domain.Management.Schedule>
{
    public void Configure(EntityTypeBuilder<Core.Domain.Management.Schedule> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .IsRequired();
        
        builder.Property(c => c.Duration)
            .IsRequired();

        builder.HasOne(c => c.Teacher)
            .WithMany(c => c.Schedules)
            .HasForeignKey(c => c.TeacherId);

        builder.HasOne(c => c.Course)
            .WithMany(c => c.Schedules)
            .HasForeignKey(c => c.CourseId);

        builder.HasOne(c => c.Classroom)
            .WithMany(c => c.Schedules)
            .HasForeignKey(c => c.ClassroomId);

        builder.ToTable("Schedules");
    }
}