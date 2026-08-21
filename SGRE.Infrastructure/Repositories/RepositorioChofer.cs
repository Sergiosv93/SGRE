using SGRE.Domain.Entities;
using SGRE.Domain.Interfaces;
using SGRE.Infrastructure.Data;

namespace SGRE.Infrastructure.Repositories
{
    public class RepositorioChofer : RepositorioBase<Chofer>, IRepositorioChofer
    {
        public RepositorioChofer(SGREDbContext contexto) : base(contexto) { }
    }
}