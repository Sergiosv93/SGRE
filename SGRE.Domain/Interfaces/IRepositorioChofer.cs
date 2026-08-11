using SGRE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRE.Domain.Interfaces
{
    public interface IRepositorioChofer : IRepositorio<Chofer>
    {
        // Por ahora solo hereda el CRUD base; se amplía si el negocio lo pide
    }
}
