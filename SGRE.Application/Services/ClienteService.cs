using System.Collections.Generic;
using SGRE.Application.Exceptions;
using SGRE.Application.Interfaces;
using SGRE.Domain.Entities;
using SGRE.Domain.Interfaces;

namespace SGRE.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IRepositorioCliente _repositorio;

        public ClienteService(IRepositorioCliente repositorio)
        {
            _repositorio = repositorio;
        }

        public Cliente ObtenerPorId(int id)
        {
            var cliente = _repositorio.ObtenerPorId(id);
            if (cliente == null)
                throw new EntidadNoEncontradaException($"No se encontró el cliente con Id {id}");

            return cliente;
        }

        public IEnumerable<Cliente> ObtenerTodos() => _repositorio.ObtenerTodos();

        public Cliente Crear(Cliente cliente)
        {
            _repositorio.Agregar(cliente);
            return cliente;
        }

        public void Actualizar(Cliente cliente)
        {
            ObtenerPorId(cliente.Id); // valida que exista antes de actualizar
            _repositorio.Actualizar(cliente);
        }
    }
}