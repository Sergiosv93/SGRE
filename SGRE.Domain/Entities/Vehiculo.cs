using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRE.Domain.Entities
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Tipo { get; set; }       // Ej: "Camioneta", "Camión", "Van"
        public decimal Capacidad { get; set; } // en kg o m3, según definan después
    }
}
