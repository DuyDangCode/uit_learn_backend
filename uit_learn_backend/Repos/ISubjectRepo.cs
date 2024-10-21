using uit_learn_backend.Models;

namespace uit_learn_backend.Repos
{
    public interface ISubjectRepo
    {
        Task<List<Subject?>> Find();
        Task<int> Create(Subject subject);

    }
}
