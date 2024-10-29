using Microsoft.AspNetCore.Mvc;
using uit_learn_backend.Attributes;
using uit_learn_backend.Constant;
using uit_learn_backend.Core;
using uit_learn_backend.Dtos;
using uit_learn_backend.Extensions;
using uit_learn_backend.Models;
using uit_learn_backend.Services;

namespace uit_learn_backend.Controllers
{
    [ApiController]
    [Route("api/v1/subjects")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectsService)
        {
            _subjectService = subjectsService;
        }

        [HttpGet("all-unPublished")]
        public async Task<IActionResult> GetAllPublished(
            [FromQuery(Name = "page")][PagingInput] int page = 1,
            [FromQuery(Name = "limit")][PagingInput] int limit = 10)
        {
            return Ok(new OkResponse<List<SubjectDto>>("Get all unpublished subjects",
                                                       (await _subjectService.GetAllUnPublished(page, limit)).ConvertToSubjectDtoList()));
        }

        [HttpGet("all-published")]
        public async Task<IActionResult> GetAllUnPublished(
            [FromQuery(Name = "page")][PagingInput] int page = 1,
            [FromQuery(Name = "limit")][PagingInput] int limit = 10)
        {
            return Ok(new OkResponse<List<SubjectDto>>(MessageStatusCode.Get("all published subjects"),
                                                    (await _subjectService.GetAllPublished(page, limit)).ConvertToSubjectDtoList()));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery(Name = "page")][PagingInput] int page = 1,
            [FromQuery(Name = "limit")][PagingInput] int limit = 10)
        {
            return Ok(new OkResponse<List<SubjectDto>>(MessageStatusCode.Get("all un-published subject"),
                                                       (await _subjectService.GetAll(page, limit)).ConvertToSubjectDtoList()));
        }

        [HttpGet("{subjectId}")]
        public async Task<IActionResult> Get([FromRoute][IdString] string subjectId)
        {
            Result<Subject> result = await _subjectService.Get(subjectId);
            if (result.IsError)
                return NotFound(new NotFoundError(subjectId));
            return Ok(new OkResponse<SubjectDto>(MessageStatusCode.Get(subjectId), new SubjectDto(result.Value)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SubjectDto newSubject)
        {
            Result<object> result = await _subjectService.Create(newSubject);
            if (result.IsError)
                BadRequest(new BadRequestError(result.ErrorMessage));
            return Created("", new CreatedResponse<object?>(
                "subject",
                result.Value));
        }

        [HttpPut("{subjectId}")]
        public async Task<IActionResult> Update([FromForm][IdString] string subjectId)
        {
            Result<object> resultUpdate = await _subjectService.Update(subjectId, new SubjectDto());
            return !resultUpdate.IsError ? Ok(new OkResponse<bool>(MessageStatusCode.Update(subjectId),
                                                          !resultUpdate.IsError)) : Ok(new NotFoundError(MessageStatusCode.NotFound(subjectId)));
        }
        [HttpDelete("{subjectId}")]
        public async Task<IActionResult> Delete([FromForm][IdString] string subjectId)
        {
            Result<object> resultUpdate = await _subjectService.Update(subjectId, new SubjectDto());
            return !resultUpdate.IsError ? Ok(new OkResponse<bool>(MessageStatusCode.Delete(subjectId),
                                                          !resultUpdate.IsError)) : Ok(new NotFoundError(MessageStatusCode.NotFound(subjectId)));
        }

    }
}