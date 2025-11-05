using System;
using Core.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Persistence.EntityConfiguration.Manager;


public class ManagerConfiguration : IEntityTypeConfiguration<Core.Domain.Employees.Manager>
{
    public void Configure(EntityTypeBuilder<Core.Domain.Employees.Manager> builder)
    {
        builder.Ignore(c => c.hasher);

        builder.ToTable("Managers");
    }
}