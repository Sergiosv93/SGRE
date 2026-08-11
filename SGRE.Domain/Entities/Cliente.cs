using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRE.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string RFC { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        // Navegación: un cliente puede tener varios envíos
        public virtual ICollection<Envio> Envios { get; set; }

        public Cliente()
        {
            Envios = new List<Envio>();
        }
    }
}
