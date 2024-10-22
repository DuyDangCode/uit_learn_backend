using Microsoft.AspNetCore.Mvc;
using uit_learn_backend.core;
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

        [HttpGet("all-unPublished")]
        public async Task<IActionResult> GetAllPublished([FromQuery(Name = "page")] int page = 1, [FromQuery(Name = "limit")] int limit = 10)
        {
            return Ok(await _subjectService.GetAllUnPublished(page, limit));
        }

        [HttpGet("all-published")]
        public async Task<IActionResult> GetAllUnPublished([FromQuery(Name = "page")] int page = 1, [FromQuery(Name = "limit")] int limit = 10)
        {
            return Ok(await _subjectService.GetAllPublished(page, limit));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery(Name = "page")] int page = 1, [FromQuery(Name = "limit")] int limit = 10)
        {
            return Ok(new OkReponse<List<Subject>>("oke", await _subjectService.GetAll(page, limit)));
        }

        [HttpGet("{subjectId}")]
        public async Task<IActionResult> GetSubject([FromRoute] string subjectId)
        {
            Subject foundedSubject = await _subjectService.Get(subjectId);
            if (foundedSubject == null)
                return NotFound();
            return Ok(foundedSubject);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromForm] SubjectDto newSubject)
        {
            return await _subjectService.Create(newSubject) ? Created() : BadRequest("Something wrong");
        }

    }
}
