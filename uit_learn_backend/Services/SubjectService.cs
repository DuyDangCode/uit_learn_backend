using uit_learn_backend.Models;
using uit_learn_backend.Repos;

namespace uit_learn_backend.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepo _subjectRepo;
        public SubjectService(ISubjectRepo subjectRepo)
        {
            _subjectRepo = subjectRepo;
        }
        public async Task<List<Subject>> GetAllPublished()
        {
            return await _subjectRepo.Find();
        }
    }
}
