using SGRE.Application.Exceptions;
using SGRE.Application.Interfaces;
using SGRE.Domain.Entities;
using SGRE.Domain.Enums;
using SGRE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRE.Application.Services
{
    public class EnvioService : IEnvioService
    {
        private readonly IRepositorioEnvio _repositorioEnvio;
        private readonly INotificador _notificador;

        // Inyección de dependencias vía constructor (principio D de SOLID)
        public EnvioService(IRepositorioEnvio repositorioEnvio, INotificador notificador)
        {
            _repositorioEnvio = repositorioEnvio;
            _notificador = notificador;
        }

        public Envio ObtenerPorId(int id)
        {
            var envio = _repositorioEnvio.ObtenerPorId(id);
            if (envio == null)
                throw new EntidadNoEncontradaException($"No se encontró el envío con Id {id}");

            return envio;
        }

        public IEnumerable<Envio> ObtenerTodos()
        {
            return _repositorioEnvio.ObtenerTodos();
        }

        public IEnumerable<Envio> ObtenerPorCliente(int clienteId)
        {
            return _repositorioEnvio.ObtenerPorCliente(clienteId);
        }

        public Envio CrearEnvio(Envio envio)
        {
            envio.Estatus = EstatusEnvio.Creado;
            _repositorioEnvio.Agregar(envio);

            _repositorioEnvio.AgregarHistorial(new EstatusHistorial
            {
                EnvioId = envio.Id,
                Estatus = EstatusEnvio.Creado,
                Comentario = "Envío registrado en el sistema"
            });

            return envio;
        }

        public void CambiarEstatus(int envioId, EstatusEnvio nuevoEstatus, string comentario)
        {
            var envio = ObtenerPorId(envioId); // reutiliza la validación de existencia

            // Regla de negocio: no se puede modificar un envío que ya fue entregado
            if (envio.Estatus == EstatusEnvio.Entregado)
                throw new ReglaDeNegocioException("No se puede modificar un envío ya entregado");

            envio.Estatus = nuevoEstatus;
            _repositorioEnvio.Actualizar(envio);

            _repositorioEnvio.AgregarHistorial(new EstatusHistorial
            {
                EnvioId = envio.Id,
                Estatus = nuevoEstatus,
                Comentario = comentario
            });

            if (nuevoEstatus == EstatusEnvio.Entregado)
                _notificador.Notificar(envio.ClienteId, "Tu envío fue entregado con éxito");
        }
    }
}
