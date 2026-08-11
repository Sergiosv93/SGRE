using SGRE.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SGRE.Application.Interfaces
{
    public interface IChoferService
    {
        Chofer ObtenerPorId(int id);
        IEnumerable<Chofer> ObtenerTodos();
        Chofer Crear(Chofer chofer);
    }
}
