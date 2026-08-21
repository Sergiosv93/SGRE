using SGRE.Domain.Entities;
using SGRE.Infrastructure.Data.Configurations;
using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace SGRE.Infrastructure.Data
{
    public class SGREDbContext : DbContext
    {
        // El nombre del connectionString debe coincidir con el Web.config
        public SGREDbContext() : base("name=SGREConnection")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Chofer> Choferes { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<EstatusHistorial> EstatusHistoriales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new VehiculoConfiguration());
            modelBuilder.Configurations.Add(new ChoferConfiguration());
            modelBuilder.Configurations.Add(new EnvioConfiguration());
            modelBuilder.Configurations.Add(new EstatusHistorialConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}