using uit_learn_backend.Models;

namespace uit_learn_backend.Repos
{
    public interface ISubjectRepo
    {
        Task<List<Subject>> Find(bool isPublished = true, bool isDeleted = false);
        Task<List<Subject>> FindAll();
        Task<List<Subject>> FindAllPublished();
        Task<List<Subject>> FindAllUnpublised();

        Task Create(Subject subject);
        Task<Subject> FindById(string id);
        Task<Subject> FindByName(string name);
        Task Delete(string id);
        Task Update(string id, Subject subject);
    }
}
