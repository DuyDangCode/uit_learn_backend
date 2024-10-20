using MongoDB.Driver;

namespace uit_learn_backend.Dbs
{
    public interface IMongoDbService
    {

        IMongoCollection<T> GetCollection<T>(string name);
        IMongoDatabase Database();
    }
}
