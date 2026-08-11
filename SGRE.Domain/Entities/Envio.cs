using SGRE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRE.Domain.Entities
{
    public class Envio
    {
        public int Id { get; set; }

        // Relaciones (Foreign Keys + navegación)
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public int ChoferId { get; set; }
        public virtual Chofer Chofer { get; set; }

        public int VehiculoId { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }

        public string OrigenDireccion { get; set; }
        public string DestinoDireccion { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaEntregaEstimada { get; set; }

        public EstatusEnvio Estatus { get; set; }

        public virtual ICollection<EstatusHistorial> Historial { get; set; }

        public Envio()
        {
            Historial = new List<EstatusHistorial>();
            FechaCreacion = DateTime.Now;
            Estatus = EstatusEnvio.Creado;
        }
    }
}
