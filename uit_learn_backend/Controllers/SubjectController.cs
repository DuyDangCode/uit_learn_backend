using Microsoft.AspNetCore.Mvc;
using uit_learn_backend.Dtos;
using uit_learn_backend.Models;
using uit_learn_backend.Services;

namespace uit_learn_backend.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
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

        [HttpPost("/")]
        public async Task<IActionResult> CreateSubject(SubjectDto newSubject)
        {
            return await _subjectService.Create(newSubject) ? Created() : BadRequest("Something wrong");
        }

    }
}
