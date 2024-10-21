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

        public Task Create(Subject subject)
        {
            return _subjectsCollection.InsertOneAsync(subject);
        }

        public async Task Delete(string id)
        {
            await _subjectsCollection.UpdateOneAsync(item => item.Id == id,
                Builders<Subject>.Update.Set(item => item.IsDeleted, true));
        }

        public async Task<List<Subject>> Find(bool isPublished = true, bool isDelete = false)
        {
            return await _subjectsCollection.Find(item => item.IsPublished == isPublished
                                                          && item.IsDeleted == isDelete).ToListAsync();
        }

        public async Task<List<Subject>> FindAll()
        {
            return await _subjectsCollection.Find(item => item.IsDeleted == false).ToListAsync();
        }

        public async Task<List<Subject>> FindAllPublished()
        {
            return await Find(true);
        }

        public async Task<List<Subject>> FindAllUnpublised()
        {
            return await Find(false);
        }

        public async Task<Subject> FindById(string id)
        {
            return await _subjectsCollection.Find(item => item.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Subject> FindByName(string name)
        {
            return await _subjectsCollection.Find(item => item.Name == name).FirstOrDefaultAsync();
        }

        public async Task Update(string id, Subject subject)
        {
            await _subjectsCollection.ReplaceOneAsync(item => item.Id == id, subject);
        }
    }
}
