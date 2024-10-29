using uit_learn_backend.Core;
using uit_learn_backend.Dtos;
using uit_learn_backend.Models;

namespace uit_learn_backend.Services
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllPublished(int page, int limit = 10);
        Task<List<Course>> GetAllUnPublished(int page, int limit = 10);
        Task<List<Course>> GetAll(int page, int limit = 10);
        Task<Result<Course>> Get(string courseId);
        Task<Result<object>> Create(CourseDto newCourse);
        Task<Result<object>> Update(string courseId, CourseDto newCourse);
        Task<Result<object>> Delete(string courseId);
    }
}
