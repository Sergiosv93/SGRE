using System.Data.Entity.ModelConfiguration;
using SGRE.Domain.Entities;

namespace SGRE.Infrastructure.Data.Configurations
{
    public class EstatusHistorialConfiguration : EntityTypeConfiguration<EstatusHistorial>
    {
        public EstatusHistorialConfiguration()
        {
            ToTable("EstatusHistorial");
            HasKey(h => h.Id);

            Property(h => h.Comentario).HasMaxLength(500);

            HasRequired(h => h.Envio)
                .WithMany(e => e.Historial)
                .HasForeignKey(h => h.EnvioId);
        }
    }
}