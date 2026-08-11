using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRE.Domain.Entities
{
    public class Chofer
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Licencia { get; set; }
        public string TelefonoEmergencia { get; set; }
    }
}
