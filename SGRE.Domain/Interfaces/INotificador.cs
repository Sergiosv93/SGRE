using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRE.Domain.Interfaces
{
    public interface INotificador
    {
        void Notificar(int clienteId, string mensaje);
    }
}
