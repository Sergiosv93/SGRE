using System.Linq;
using SGRE.Domain.Entities;
using SGRE.Domain.Interfaces;
using SGRE.Infrastructure.Data;

namespace SGRE.Infrastructure.Repositories
{
    public class RepositorioVehiculo : RepositorioBase<Vehiculo>, IRepositorioVehiculo
    {
        public RepositorioVehiculo(SGREDbContext contexto) : base(contexto) { }

        public Vehiculo ObtenerPorPlaca(string placa)
        {
            return Contexto.Vehiculos.FirstOrDefault(v => v.Placa == placa);
        }
    }
}