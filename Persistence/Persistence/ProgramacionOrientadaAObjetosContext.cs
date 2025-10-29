using System;
using Microsoft.EntityFrameworkCore;
using Persistence.Persistence.EntityConfiguration.Livestock;
using Core.Domain.Livestock;

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

            modelBuilder.ApplyConfiguration(new AnimalConfiguration());

            #endregion

            #region Seeds

            #endregion
        }

        #region Entities

        public DbSet<Animal> Animals { get; set; }

        #endregion
    }
}