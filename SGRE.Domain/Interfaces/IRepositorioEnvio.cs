using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGRE.Domain.Entities;
using SGRE.Domain.Enums;

namespace SGRE.Domain.Interfaces
{
    public interface IRepositorioEnvio : IRepositorio<Envio>
    {
        IEnumerable<Envio> ObtenerPorEstatus(EstatusEnvio estatus);
        IEnumerable<Envio> ObtenerPorCliente(int clienteId);
        void AgregarHistorial(EstatusHistorial historial);
    }
}
