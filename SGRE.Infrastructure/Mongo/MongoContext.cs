using MongoDB.Driver;
using SGRE.Domain.Documents;

namespace SGRE.Infrastructure.Mongo
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<EvidenciaEntrega> Evidencias =>
            _database.GetCollection<EvidenciaEntrega>("EvidenciasEntrega");
    }
}