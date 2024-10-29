using uit_learn_backend.Core;
using uit_learn_backend.Dtos;
using uit_learn_backend.Models;

namespace uit_learn_backend.Services
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetAllPublished(int page, int limit = 10);
        Task<List<Subject>> GetAllUnPublished(int page, int limit = 10);
        Task<List<Subject>> GetAll(int page, int limit = 10);
        Task<Result<Subject>> Get(string subjectId);
        Task<Result<object>> Create(SubjectDto newSubject);
        Task<Result<object>> Update(string subjectId, SubjectDto newSubject);
        Task<Result<object>> Delete(string subjectId);
    }
}
