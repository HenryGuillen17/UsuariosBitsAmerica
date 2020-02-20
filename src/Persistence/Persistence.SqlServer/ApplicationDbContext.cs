using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using System.Text;
using Models.Dao;
using Persistence.SqlServer.Config;

namespace Persistence.SqlServer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options
        ) : base(options)
        {
            //ChangeTracker.AutoDetectChangesEnabled = false;
            //ChangeTracker.LazyLoadingEnabled = true;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new CiudadConfig(modelBuilder.Entity<Ciudad>());
            new UsuarioConfig(modelBuilder.Entity<Usuario>());
        }
    }
}
