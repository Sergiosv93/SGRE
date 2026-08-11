using SGRE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRE.Application.Interfaces
{
    public interface IClienteService
    {
        Cliente ObtenerPorId(int id);
        IEnumerable<Cliente> ObtenerTodos();
        Cliente Crear(Cliente cliente);
        void Actualizar(Cliente cliente);
    }
}
