using System;
using Core.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Persistence.EntityConfiguration.Teacher;


public class TeacherConfiguration : IEntityTypeConfiguration<Core.Domain.Employees.Teacher>
{
    public void Configure(EntityTypeBuilder<Core.Domain.Employees.Teacher> builder)
    {
        builder.ToTable("Teacher");
    }
}