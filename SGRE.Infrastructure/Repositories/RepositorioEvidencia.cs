using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using SGRE.Domain.Documents;
using SGRE.Domain.Interfaces;
using SGRE.Infrastructure.Mongo;

namespace SGRE.Infrastructure.Repositories
{
    public class RepositorioEvidencia : IRepositorioEvidencia
    {
        private readonly MongoContext _mongoContext;

        public RepositorioEvidencia(MongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public void Guardar(EvidenciaEntrega evidencia)
        {
            _mongoContext.Evidencias.InsertOne(evidencia);
        }

        public EvidenciaEntrega ObtenerPorEnvioId(int envioId)
        {
            return _mongoContext.Evidencias
                .Find(e => e.EnvioId == envioId)
                .FirstOrDefault();
        }

        public IEnumerable<EvidenciaEntrega> ObtenerTodas()
        {
            return _mongoContext.Evidencias.Find(_ => true).ToList();
        }
    }
}