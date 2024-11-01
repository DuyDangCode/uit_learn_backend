using uit_learn_backend.Models;

namespace uit_learn_backend.Repos
{
    public interface ICourseRepo
    {
        Task<List<Course>> Find(int limit, int skip, bool isPublished = true, bool isDeleted = false);
        Task<List<Course>> FindAll(int limit, int skip);
        Task<List<Course>> FindAllPublished(int limit, int skip);
        Task<List<Course>> FindAllUnPublised(int limit, int skip);

        Task Create(Course newCourse);
        Task<Course> FindById(string? id);
        Task<Course> FindByCode(string? code);
        Task<Course> FindByCodeOrId(string? code, string? id);
        Task<Course> FindByName(string name);
        Task<bool> Delete(string code);
        bool Update(string code, Course newCourse);

    }
}
