using System;
using Core.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Persistence.EntityConfiguration.Schedule;


public class ScheduleConfiguration : IEntityTypeConfiguration<Core.Domain.Management.Schedule>
{
    public void Configure(EntityTypeBuilder<Core.Domain.Management.Schedule> builder)
    {
        builder.HasOne(c => c.Class)
            .WithOne(c => c.Schedule);

        builder.ToTable("Schedules");
    }
}