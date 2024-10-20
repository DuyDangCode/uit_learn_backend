using MongoDB.Driver;
using uit_learn_backend.Dbs;
using uit_learn_backend.Models;

namespace uit_learn_backend.Services
{
    public class SubjectsService : ISubjectsService
    {
        private IMongoCollection<Subjects> _subjectsCollection;
        public SubjectsService(IMongoDbService mongoDbService)
        {
            _subjectsCollection = mongoDbService.GetCollection<Subjects>("subjects");
        }
        public async Task<List<Subjects>> GetAllPublished()
        {
            return await _subjectsCollection.Find(_ => true).ToListAsync();
        }
    }
}
