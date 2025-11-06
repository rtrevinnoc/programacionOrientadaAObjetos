using System;
using Microsoft.EntityFrameworkCore;
using Persistence.Persistence.EntityConfiguration.Livestock;
using Core.Domain.Livestock;
using Core.Domain.Locations;
using Core.Domain.Taxonomy;
using Persistence.Persistence.EntityConfigurations.Taxonomy;
using Persistence.Persistence.EntityConfigurations.Locations;
using Persistence.Persistence.EntityConfigurations.People;
using Core.Domain.People;

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
            modelBuilder.ApplyConfiguration(new BreedConfiguration());
            modelBuilder.ApplyConfiguration(new SpecieConfiguration());
            modelBuilder.ApplyConfiguration(new RanchConfiguration());
            modelBuilder.ApplyConfiguration(new RancherConfiguration());
            modelBuilder.ApplyConfiguration(new CorralConfiguration());
            modelBuilder.Entity<Animal>().UseTptMappingStrategy();

            #endregion

            #region Seeds

            #endregion
        }

        #region Entities

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Horse> Horses { get; set; }
        public DbSet<Goat> Goats { get; set; }
        public DbSet<Ranch> Ranches { get; set; }
        public DbSet<Corral> Corrals { get; set; }
        public DbSet<Rancher> Ranchers { get; set; }
        public DbSet<Specie> Species { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        #endregion
    }
}