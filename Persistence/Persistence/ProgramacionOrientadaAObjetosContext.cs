using System;
using Microsoft.EntityFrameworkCore;
using Persistence.Persistence.EntityConfiguration.Employees;
using Core.Domain.Employees;
using Persistence.Persistence.EntityConfiguration.Documents;
using Core.Domain.Documents;

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

            #endregion

            #region Seeds

            #endregion
        }

        #region Entities

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Document> Documents { get; set;  }

        #endregion
    }
}