using System.Data.Entity.ModelConfiguration;
using SGRE.Domain.Entities;

namespace SGRE.Infrastructure.Data.Configurations
{
    public class ChoferConfiguration : EntityTypeConfiguration<Chofer>
    {
        public ChoferConfiguration()
        {
            ToTable("Choferes");
            HasKey(c => c.Id);

            Property(c => c.Nombre).IsRequired().HasMaxLength(150);
            Property(c => c.Licencia).IsRequired().HasMaxLength(30);
            Property(c => c.TelefonoEmergencia).HasMaxLength(20);
        }
    }
}