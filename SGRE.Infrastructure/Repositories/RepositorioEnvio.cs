using System.Collections.Generic;
using System.Linq;
using SGRE.Domain.Entities;
using SGRE.Domain.Enums;
using SGRE.Domain.Interfaces;
using SGRE.Infrastructure.Data;

namespace SGRE.Infrastructure.Repositories
{
    public class RepositorioEnvio : RepositorioBase<Envio>, IRepositorioEnvio
    {
        public RepositorioEnvio(SGREDbContext contexto) : base(contexto) { }

        public IEnumerable<Envio> ObtenerPorEstatus(EstatusEnvio estatus)
        {
            return Contexto.Envios.Where(e => e.Estatus == estatus).ToList();
        }

        public IEnumerable<Envio> ObtenerPorCliente(int clienteId)
        {
            return Contexto.Envios.Where(e => e.ClienteId == clienteId).ToList();
        }

        public void AgregarHistorial(EstatusHistorial historial)
        {
            Contexto.EstatusHistoriales.Add(historial);
            Contexto.SaveChanges();
        }
    }
}