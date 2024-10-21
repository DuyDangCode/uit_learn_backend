using Microsoft.AspNetCore.Mvc;
using uit_learn_backend.Dtos;
using uit_learn_backend.Models;
using uit_learn_backend.Services;

namespace uit_learn_backend.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectsService)
        {
            _subjectService = subjectsService;
        }

        [HttpGet]
        public async Task<List<Subject>> GetSubjects([FromQuery(Name = "page")] int page = 1, [FromQuery(Name = "limit")] int limit = 10)
        {
            return await _subjectService.GetAllPublished(page, limit);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromForm] SubjectDto newSubject)
        {
            return await _subjectService.Create(newSubject) ? Created() : BadRequest("Something wrong");
        }

    }
}
