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
    [Route("api/v1/courses/")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CourseDto newCourse)
        {
            Result<object> result = await _courseService.Create(newCourse);
            if (result.IsError) return BadRequest(new BadRequestError(result.ErrorMessage));
            return Created("", new CreatedResponse<object?>("course", result.Value));
        }

        [HttpGet("all-published")]
        public async Task<IActionResult> GetAllPublished([FromQuery(Name = "page")][PagingInput] int page = 1,
                                                   [FromQuery(Name = "limit")][PagingInput] int limit = 10)
        {
            return Ok(new OkResponse<List<CourseDto>>(MessageStatusCode.Get("all published course"),
                                                       (await _courseService.GetAllPublished(page, limit)).ConvertToCourseDtoList()));
        }

        [HttpGet("all-unPublished")]
        public async Task<IActionResult> GetAllUnPublished([FromQuery(Name = "page")][PagingInput] int page = 1,
                                                     [FromQuery(Name = "limit")][PagingInput] int limit = 10)
        {
            return Ok(new OkResponse<List<CourseDto>>(MessageStatusCode.Get("all un-published course"),
                                                                   (await _courseService.GetAllUnPublished(page, limit)).ConvertToCourseDtoList()));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery(Name = "page")][PagingInput] int page = 1,
                                          [FromQuery(Name = "limit")][PagingInput] int limit = 10)
        {
            return Ok(new OkResponse<List<CourseDto>>(MessageStatusCode.Get("all published course"),
                                                                   (await _courseService.GetAll(page, limit)).ConvertToCourseDtoList()));
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetOne([FromForm()][Code] string code)
        {
            Result<Course> result = await _courseService.Get(code);
            if (result.IsError) return NotFound(new NotFoundError(code));

            return Ok(new OkResponse<CourseDto>(MessageStatusCode.Get("all published course"),
                                                                   new CourseDto(result.Value)));
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update([FromForm][Code] string code, [FromBody] CourseDto newCourse)
        {
            Result<object> result = await _courseService.Update(code, newCourse);
            if (result.IsError) return BadRequest(new BadRequestError(result.ErrorMessage));

            return Ok(new OkResponse<object?>(MessageStatusCode.Update("course"), result.Value));
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete([FromForm][Code] string code)
        {
            Result<object> result = await _courseService.Delete(code);
            if (result.IsError) return NotFound(new NotFoundError(result.ErrorMessage));
            return Ok(new OkResponse<object?>(MessageStatusCode.Delete("course"), result.Value));
        }
    }
}