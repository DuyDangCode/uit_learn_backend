using MongoDB.Driver;
using uit_learn_backend.Dbs;
using uit_learn_backend.Models;

namespace uit_learn_backend.Repos
{
    public class CourseRepo : ICourseRepo
    {
        private readonly IMongoCollection<Course> _courseCollection;
        private readonly ISubjectRepo _subjectRepo;
        public CourseRepo(IMongoDbService mongoDbService, ISubjectRepo subjectRepo)
        {
            _courseCollection = mongoDbService.GetCollection<Course>("courses");
            _subjectRepo = subjectRepo;
        }

        public Task Create(Course newCourse)
        {
            return _courseCollection.InsertOneAsync(newCourse);
        }

        public async Task<bool> Delete(string id)
        {
            var filter = Builders<Course>.Filter.Eq(course => course.Id, id);
            var update = Builders<Course>.Update.Set("course_is_deleted", true);
            var result = await _courseCollection.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public Task<List<Course>> Find(int limit, int skip, bool isPublished = true, bool isDeleted = false)
        {
            return _courseCollection.Find(course => course.IsPublished == isPublished && course.IsDeleted == isDeleted)
                .Limit(limit)
                .Skip(skip)
                .ToListAsync();
        }

        public Task<List<Course>> FindAll(int limit, int skip)
        {
            return _courseCollection.Find(course => true)
                .Limit(limit)
                .Skip(skip)
                .ToListAsync();
        }

        public Task<List<Course>> FindAllPublished(int limit, int skip)
        {
            return Find(limit, skip, true, false);
        }

        public Task<List<Course>> FindAllUnPublised(int limit, int skip)
        {
            return Find(limit, skip, false, false);
        }

        public Task<Course> FindByCode(string? code)
        {
            return _courseCollection.Find(course => course.Code == code).FirstOrDefaultAsync();
        }

        public Task<Course> FindByCodeOrId(string? code, string? id)
        {
            return _courseCollection.Find(course => course.Code == code || course.Id == id).FirstOrDefaultAsync();
        }

        public Task<Course> FindById(string? id)
        {
            return _courseCollection.Find(course => course.Id == id).FirstOrDefaultAsync();
        }

        public Task<Course> FindByName(string name)
        {
            return _courseCollection.Find(course => course.Name == name).FirstOrDefaultAsync();
        }

        public bool Update(string id, Course newCourse)
        {

            var result = _courseCollection.ReplaceOneAsync(course => course.Id == id, newCourse).Result;
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
