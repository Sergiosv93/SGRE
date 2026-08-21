using System.Data.Entity.ModelConfiguration;
using SGRE.Domain.Entities;

namespace SGRE.Infrastructure.Data.Configurations
{
    public class EnvioConfiguration : EntityTypeConfiguration<Envio>
    {
        public EnvioConfiguration()
        {
            ToTable("Envios");
            HasKey(e => e.Id);

            Property(e => e.OrigenDireccion).IsRequired().HasMaxLength(300);
            Property(e => e.DestinoDireccion).IsRequired().HasMaxLength(300);
            Property(e => e.Estatus).IsRequired();

            // Relaciones (FKs)
            HasRequired(e => e.Cliente)
                .WithMany(c => c.Envios)
                .HasForeignKey(e => e.ClienteId);

            HasRequired(e => e.Chofer)
                .WithMany()
                .HasForeignKey(e => e.ChoferId);

            HasRequired(e => e.Vehiculo)
                .WithMany()
                .HasForeignKey(e => e.VehiculoId);
        }
    }
}