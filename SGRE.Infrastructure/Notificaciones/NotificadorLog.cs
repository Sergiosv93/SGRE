using System;
using System.Diagnostics;
using SGRE.Domain.Interfaces;

namespace SGRE.Infrastructure.Notificaciones
{
    // Implementación simple para el prototipo: registra la notificación en el Output de Debug.
    // En un escenario real, aquí se conectaría un servicio de correo o SMS,
    // sin necesidad de tocar SGRE.Application (principio Open/Closed).
    public class NotificadorLog : INotificador
    {
        public void Notificar(int clienteId, string mensaje)
        {
            var registro = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Notificación a Cliente #{clienteId}: {mensaje}";
            Debug.WriteLine(registro);
        }
    }
}