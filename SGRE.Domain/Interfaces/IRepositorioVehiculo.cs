using SGRE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRE.Domain.Interfaces
{
    public interface IRepositorioVehiculo : IRepositorio<Vehiculo>
    {
        Vehiculo ObtenerPorPlaca(string placa);
    }
}
