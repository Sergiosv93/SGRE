using System.Data.Entity.ModelConfiguration;
using SGRE.Domain.Entities;

namespace SGRE.Infrastructure.Data.Configurations
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            ToTable("Clientes");
            HasKey(c => c.Id);

            Property(c => c.Nombre).IsRequired().HasMaxLength(150);
            Property(c => c.RFC).IsRequired().HasMaxLength(13);
            Property(c => c.Telefono).HasMaxLength(20);
            Property(c => c.Direccion).HasMaxLength(300);
        }
    }
}