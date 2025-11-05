using System;
using Core.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Persistence.EntityConfiguration.Prefect;


public class PrefectConfiguration : IEntityTypeConfiguration<Core.Domain.Employees.Prefect>
{
    public void Configure(EntityTypeBuilder<Core.Domain.Employees.Prefect> builder)
    {
        builder.HasMany(c => c.LLaves)
            .WithOne(c => c.Prefect)
            .HasForeignKey(c => c.PrefectId);

        builder.ToTable("Teachers");
    }
}