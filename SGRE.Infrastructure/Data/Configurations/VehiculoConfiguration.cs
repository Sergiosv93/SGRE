using System.Data.Entity.ModelConfiguration;
using SGRE.Domain.Entities;

namespace SGRE.Infrastructure.Data.Configurations
{
    public class VehiculoConfiguration : EntityTypeConfiguration<Vehiculo>
    {
        public VehiculoConfiguration()
        {
            ToTable("Vehiculos");
            HasKey(v => v.Id);

            Property(v => v.Placa).IsRequired().HasMaxLength(15);
            Property(v => v.Tipo).IsRequired().HasMaxLength(50);
            Property(v => v.Capacidad).HasPrecision(10, 2);
        }
    }
}