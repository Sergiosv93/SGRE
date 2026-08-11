using SGRE.Application.Exceptions;
using SGRE.Application.Interfaces;
using SGRE.Domain.Entities;
using SGRE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRE.Application.Services
{
    public class VehiculoService: IVehiculoService
    {
        private readonly IRepositorioVehiculo _repositorioVehiculo;

        public VehiculoService(IRepositorioVehiculo repositorioVehiculo)
        {
            _repositorioVehiculo = repositorioVehiculo;
        }

        public Vehiculo Crear(Vehiculo vehiculo)
        {
            _repositorioVehiculo.Agregar(vehiculo);
            return vehiculo;
        }

        public Vehiculo ObtenerPorId(int id)
        {
            var vehiculo = _repositorioVehiculo.ObtenerPorId(id);
            if (vehiculo == null)
            {
                throw new EntidadNoEncontradaException($"No se encontró el vehiculo con Id {id}");
            }

            return vehiculo;
        }

        public IEnumerable<Vehiculo> ObtenerTodos() => _repositorioVehiculo.ObtenerTodos();
    }
}
