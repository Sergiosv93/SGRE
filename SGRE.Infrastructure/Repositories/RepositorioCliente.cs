using System.Linq;
using SGRE.Domain.Entities;
using SGRE.Domain.Interfaces;
using SGRE.Infrastructure.Data;

namespace SGRE.Infrastructure.Repositories
{
    public class RepositorioCliente : RepositorioBase<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(SGREDbContext contexto) : base(contexto) { }

        public Cliente ObtenerPorRFC(string rfc)
        {
            return Contexto.Clientes.FirstOrDefault(c => c.RFC == rfc);
        }
    }
}