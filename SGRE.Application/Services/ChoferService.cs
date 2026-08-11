using SGRE.Application.Exceptions;
using SGRE.Application.Interfaces;
using SGRE.Domain.Entities;
using SGRE.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace SGRE.Application.Services
{
    public class ChoferService : IChoferService
    {
        private readonly IRepositorioChofer _repositorio;

        public ChoferService(IRepositorioChofer repositorio)
        {
            _repositorio = repositorio;
        }

        public Chofer ObtenerPorId(int id)
        {
            var chofer = _repositorio.ObtenerPorId(id);
            if (chofer == null)
                throw new EntidadNoEncontradaException($"No se encontró el chofer con Id {id}");

            return chofer;
        }

        public IEnumerable<Chofer> ObtenerTodos() => _repositorio.ObtenerTodos();

        public Chofer Crear(Chofer chofer)
        {
            _repositorio.Agregar(chofer);
            return chofer;
        }
    }
}
