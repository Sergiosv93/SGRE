using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRE.Application.Exceptions
{
    // Se lanza cuando una operación viola una regla del negocio
    // (ej. intentar marcar como "Entregado" un envío ya cancelado)
    public class ReglaDeNegocioException : Exception
    {
        public ReglaDeNegocioException(string mensaje) : base(mensaje) { }
    }
}
