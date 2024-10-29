using Microsoft.Extensions.Options;
using MongoDB.Driver;
using uit_learn_backend.Config;

namespace uit_learn_backend.Dbs
{
    public class MongoDbService : IMongoDbService
    {
        private IMongoDatabase _database;
        public MongoDbService(IOptions<MongoDbConfig> config)
        {
            var mongoClient = new MongoClient(config.Value.ConnectionString);
            _database = mongoClient.GetDatabase(config.Value.DatabaseName);
        }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
        public IMongoDatabase Database() => _database;
    }
}
