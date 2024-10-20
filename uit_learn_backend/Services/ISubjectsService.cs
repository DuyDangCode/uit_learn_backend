using uit_learn_backend.Models;

namespace uit_learn_backend.Services
{
    public interface ISubjectsService
    {
        Task<List<Subjects>> GetAllPublished();
    }
}
