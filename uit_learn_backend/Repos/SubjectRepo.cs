using MongoDB.Driver;
using uit_learn_backend.Dbs;
using uit_learn_backend.Models;

namespace uit_learn_backend.Repos
{
    public class SubjectRepo : ISubjectRepo
    {
        private IMongoCollection<Subject> _subjectsCollection;
        public SubjectRepo(IMongoDbService mongoDbService)
        {
            _subjectsCollection = mongoDbService.GetCollection<Subject>("subjects");
        }

        public async Task<List<Subject>> Find()
        {
            return await _subjectsCollection.Find(s => true).ToListAsync();
        }
    }
}
