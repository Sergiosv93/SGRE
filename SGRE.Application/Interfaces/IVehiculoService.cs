using SGRE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRE.Application.Interfaces
{
    public interface IVehiculoService
    {
        Vehiculo ObtenerPorId(int id);
        IEnumerable<Vehiculo> ObtenerTodos();
        Vehiculo Crear(Vehiculo vehiculo);
    }
}
