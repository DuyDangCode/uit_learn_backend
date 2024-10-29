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
        public async Task<IActionResult> Create([FromBody] CourseDto newCourse)
        {
            Result<object> result = await _courseService.Create(newCourse);
            if (result.IsError) return BadRequest(new BadRequestError(MessageStatusCode.Exists("course")));
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
        public async Task<IActionResult> GetAllUnPubliesed([FromQuery(Name = "page")][PagingInput] int page = 1,
                                                     [FromQuery(Name = "limit")][PagingInput] int limit = 10)
        {
            return Ok(new OkResponse<List<CourseDto>>(MessageStatusCode.Get("all un-published course"),
                                                                   (await _courseService.GetAllUnPublished(page, limit)).ConvertToCourseDtoList()));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery(Name = "page")][PagingInput] int page = 1,
                                          [FromQuery(Name = "limie")][PagingInput] int limit = 10)
        {
            return Ok(new OkResponse<List<CourseDto>>(MessageStatusCode.Get("all published course"),
                                                                   (await _courseService.GetAll(page, limit)).ConvertToCourseDtoList()));
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetOne([FromForm()] string courseId)
        {
            Result<Course> result = await _courseService.Get(courseId);
            if (result.IsError) return NotFound(new NotFoundError(courseId));

            return Ok(new OkResponse<CourseDto>(MessageStatusCode.Get("all published course"),
                                                                   new CourseDto(result.Value)));
        }

        [HttpPut("{courseId}")]
        public async Task<IActionResult> Update([FromForm] string courseId, [FromBody] CourseDto newCourse)
        {
            Result<object> result = await _courseService.Update(courseId, newCourse);
            if (result.IsError) return BadRequest(new BadRequestError(result.ErrorMessage));

            return Ok(new OkResponse<object?>(MessageStatusCode.Update("course"), result.Value));
        }

        [HttpDelete("{courseId}")]
        public async Task<IActionResult> Delete([FromForm] string courseId)
        {
            Result<object> result = await _courseService.Delete(courseId);
            if (result.IsError) return NotFound(new NotFoundError(result.ErrorMessage));
            return Ok(new OkResponse<object?>(MessageStatusCode.Delete("course"), result.Value));
        }
    }
}