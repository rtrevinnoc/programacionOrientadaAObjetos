using System;
using Microsoft.EntityFrameworkCore;
using Persistence.Persistence.EntityConfiguration.Employees;
using Core.Domain.Employees;
using Persistence.Persistence.EntityConfiguration.Documents;
using Core.Domain.Documents;
using Persistence.Persistence.EntityConfiguration.Teacher;
using Persistence.Persistence.EntityConfiguration.Course;
using Persistence.Migrations;
using Core.Domain.Management;
using Persistence.Persistence.EntityConfiguration.Classroom;
using Persistence.Persistence.EntityConfiguration.Llave;
using Persistence.Persistence.EntityConfiguration.Manager;

namespace Persistence.Persistence
{
    public sealed class ProgramacionOrientadaAObjetosContext : DbContext
    {
        public ProgramacionOrientadaAObjetosContext(DbContextOptions<ProgramacionOrientadaAObjetosContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Models

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new ClassroomConfiguration());
            modelBuilder.ApplyConfiguration(new LlaveConfiguration());
            modelBuilder.ApplyConfiguration(new ManagerConfiguration());

            #endregion

            #region Seeds

            #endregion
        }

        #region Entities

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Llave> Llaves { get; set; }
        public DbSet<Manager> Managers { get; set; }

        #endregion
    }
}