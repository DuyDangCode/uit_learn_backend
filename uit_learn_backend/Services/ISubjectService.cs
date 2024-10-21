using uit_learn_backend.Dtos;
using uit_learn_backend.Models;

namespace uit_learn_backend.Services
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetAllPublished();
        Task<bool> Create(SubjectDto newSubject);
    }
}
