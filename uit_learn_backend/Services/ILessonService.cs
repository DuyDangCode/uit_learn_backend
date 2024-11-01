using uit_learn_backend.Core;
using uit_learn_backend.Models;

namespace uit_learn_backend.Services
{
    public interface ILessonService
    {
        Task<List<Lesson>> GetAllPublished(int page, int limit = 10);
        Task<List<Lesson>> GetAllUnPublished(int page, int limit = 10);
        Task<List<Lesson>> GetAll(int page, int limit = 10);
        Task<Result<Lesson>> Get(string code);
        Task<Result<object>> Create(Lesson newLesson);
        Task<Result<object>> Update(string code, Lesson newLesson);
        Task<Result<object>> Delete(string code);

    }
}
