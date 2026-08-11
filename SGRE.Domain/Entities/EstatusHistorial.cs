using SGRE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRE.Domain.Entities
{
    public class EstatusHistorial
    {
        public int Id { get; set; }

        public int EnvioId { get; set; }
        public virtual Envio Envio { get; set; }

        public EstatusEnvio Estatus { get; set; }
        public DateTime FechaCambio { get; set; }
        public string Comentario { get; set; }

        public EstatusHistorial()
        {
            FechaCambio = DateTime.Now;
        }
    }
}
