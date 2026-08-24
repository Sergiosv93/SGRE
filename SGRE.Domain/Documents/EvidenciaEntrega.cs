using System;
using System.Collections.Generic;

namespace SGRE.Domain.Documents
{
    // Documento no relacional: representa evidencia fotográfica/firma de una entrega.
    // Vive en MongoDB, no en SQL Server -- por eso no tiene atributos de EF.
    public class EvidenciaEntrega
    {
        public string Id { get; set; } // Mongo usa string (ObjectId) como Id por convención
        public int EnvioId { get; set; } // FK "lógica" hacia SQL Server (Envios.Id)
        public DateTime Fecha { get; set; }
        public List<string> FotosBase64 { get; set; }
        public string FirmaReceptorBase64 { get; set; }
        public string Notas { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        public EvidenciaEntrega()
        {
            FotosBase64 = new List<string>();
            Fecha = DateTime.Now;
        }
    }
}