using uit_learn_backend.Dtos;
using uit_learn_backend.Models;

namespace uit_learn_backend.Services
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetAllPublished(int page, int limit = 10);
        //Task<List<Subject>> GetAllUnPublished();
        //Task<List<Subject>> GetAll();
        Task<bool> Create(SubjectDto newSubject);
    }
}
