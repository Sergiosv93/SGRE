using SGRE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRE.Domain.Interfaces
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        Cliente ObtenerPorRFC(string rfc);
    }
}
