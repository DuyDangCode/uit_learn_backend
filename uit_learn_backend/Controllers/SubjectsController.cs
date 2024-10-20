using Microsoft.AspNetCore.Mvc;
using uit_learn_backend.Models;
using uit_learn_backend.Services;

namespace uit_learn_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectsService _subjectService;
        public SubjectsController(ISubjectsService subjectsService)
        {
            _subjectService = subjectsService;
        }

        [HttpGet("/")]
        public async Task<List<Subjects>> GetSubjects()
        {
            return await _subjectService.GetAllPublished();
        }

    }
}
