using uit_learn_backend.Models;

namespace uit_learn_backend.Repos
{
    public interface ISubjectRepo
    {
        Task<List<Subject>> Find(int limit, int skip, bool isPublished = true, bool isDeleted = false);
        Task<List<Subject>> FindAll(int limit, int skip);
        Task<List<Subject>> FindAllPublished(int limit, int skip);
        Task<List<Subject>> FindAllUnPublised(int limit, int skip);

        Task Create(Subject subject);
        Task<Subject> FindById(string id);
        Task<Subject> FindByCode(string code);
        Task<Subject> FindByCodeOrId(string? code, string? id);
        Task<Subject> FindByName(string name);
        Task Delete(string id);
        Task Update(string id, Subject subject);
    }
}
