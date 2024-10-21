using Microsoft.AspNetCore.Mvc;
using uit_learn_backend.Models;
using uit_learn_backend.Services;

namespace uit_learn_backend.Controllers
{
    [ApiController]
    [Route("/api/v1/subjects")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectsService)
        {
            _subjectService = subjectsService;
        }

        [HttpGet("/")]
        public async Task<List<Subject>> GetSubjects()
        {
            return await _subjectService.GetAllPublished();
        }

    }
}
