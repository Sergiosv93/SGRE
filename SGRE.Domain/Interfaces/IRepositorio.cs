using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRE.Domain.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        T ObtenerPorId(int id);
        IEnumerable<T> ObtenerTodos();
        void Agregar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(int id);
    }
}
