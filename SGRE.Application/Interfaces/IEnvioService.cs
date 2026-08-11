using SGRE.Domain.Entities;
using SGRE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRE.Application.Interfaces
{
    public interface IEnvioService
    {
        Envio ObtenerPorId(int id);
        IEnumerable<Envio> ObtenerTodos();
        IEnumerable<Envio> ObtenerPorCliente(int clienteId);

        Envio CrearEnvio(Envio envio);
        void CambiarEstatus(int envioId, EstatusEnvio nuevoEstatus, string comentario);
    }
}
