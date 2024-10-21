using MongoDB.Driver;
using uit_learn_backend.Dbs;
using uit_learn_backend.Models;

namespace uit_learn_backend.Services
{
    public class SubjectService : ISubjectService
    {
        private IMongoCollection<Subject> _subjectsCollection;
        public SubjectService(IMongoDbService mongoDbService)
        {
            _subjectsCollection = mongoDbService.GetCollection<Subject>("subjects");
        }
        public async Task<List<Subject>> GetAllPublished()
        {
            return await _subjectsCollection.Find(_ => true).ToListAsync();
        }
    }
}
