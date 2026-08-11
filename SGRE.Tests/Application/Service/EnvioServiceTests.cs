using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SGRE.Application.Exceptions;
using SGRE.Application.Services;
using SGRE.Domain.Entities;
using SGRE.Domain.Enums;
using SGRE.Domain.Interfaces;

namespace SGRE.Tests.Application.Services
{
    [TestClass]
    public class EnvioServiceTests
    {
        private Mock<IRepositorioEnvio> _repositorioMock;
        private Mock<INotificador> _notificadorMock;
        private EnvioService _servicio;

        // Se ejecuta antes de CADA prueba - evita repetir el mismo setup
        [TestInitialize]
        public void Setup()
        {
            _repositorioMock = new Mock<IRepositorioEnvio>();
            _notificadorMock = new Mock<INotificador>();
            _servicio = new EnvioService(_repositorioMock.Object, _notificadorMock.Object);
        }

        [TestMethod]
        public void ObtenerPorId_CuandoExiste_RegresaElEnvio()
        {
            // Arrange
            var envio = new Envio { Id = 1, ClienteId = 10 };
            _repositorioMock.Setup(r => r.ObtenerPorId(1)).Returns(envio);

            // Act
            var resultado = _servicio.ObtenerPorId(1);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(1, resultado.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(EntidadNoEncontradaException))]
        public void ObtenerPorId_CuandoNoExiste_LanzaExcepcion()
        {
            // Arrange
            _repositorioMock.Setup(r => r.ObtenerPorId(It.IsAny<int>())).Returns((Envio)null);

            // Act
            _servicio.ObtenerPorId(999);

            // Assert -> lo maneja el atributo ExpectedException
        }

        [TestMethod]
        public void CrearEnvio_AsignaEstatusCreadoYRegistraHistorial()
        {
            // Arrange
            var envio = new Envio { ClienteId = 5, ChoferId = 1, VehiculoId = 1 };

            // Act
            var resultado = _servicio.CrearEnvio(envio);

            // Asserte
            Assert.AreEqual(EstatusEnvio.Creado, resultado.Estatus);
            _repositorioMock.Verify(r => r.Agregar(envio), Times.Once);
            _repositorioMock.Verify(r => r.AgregarHistorial(
                It.Is<EstatusHistorial>(h => h.Estatus == EstatusEnvio.Creado)),
                Times.Once);
        }

        [TestMethod]
        public void CambiarEstatus_CuandoEsEntregado_NotificaAlCliente()
        {
            // Arrange
            var envio = new Envio { Id = 1, ClienteId = 5, Estatus = EstatusEnvio.EnTransito };
            _repositorioMock.Setup(r => r.ObtenerPorId(1)).Returns(envio);

            // Act
            _servicio.CambiarEstatus(1, EstatusEnvio.Entregado, "Entregado en recepción");

            // Assert
            Assert.AreEqual(EstatusEnvio.Entregado, envio.Estatus);
            _notificadorMock.Verify(n => n.Notificar(5, It.IsAny<string>()), Times.Once);
            _repositorioMock.Verify(r => r.Actualizar(envio), Times.Once);
        }

        [TestMethod]
        public void CambiarEstatus_CuandoNoEsEntregado_NoNotifica()
        {
            // Arrange
            var envio = new Envio { Id = 1, ClienteId = 5, Estatus = EstatusEnvio.Creado };
            _repositorioMock.Setup(r => r.ObtenerPorId(1)).Returns(envio);

            // Act
            _servicio.CambiarEstatus(1, EstatusEnvio.EnTransito, "Salió a ruta");

            // Assert - caso límite: solo se notifica en "Entregado", no en cualquier cambio
            _notificadorMock.Verify(n => n.Notificar(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        [ExpectedException(typeof(ReglaDeNegocioException))]
        public void CambiarEstatus_CuandoYaFueEntregado_LanzaExcepcion()
        {
            // Arrange - caso límite: no se puede modificar un envío ya cerrado
            var envio = new Envio { Id = 1, ClienteId = 5, Estatus = EstatusEnvio.Entregado };
            _repositorioMock.Setup(r => r.ObtenerPorId(1)).Returns(envio);

            // Act
            _servicio.CambiarEstatus(1, EstatusEnvio.Incidencia, "Intento inválido");

            // Assert -> lo maneja ExpectedException
        }
    }
}