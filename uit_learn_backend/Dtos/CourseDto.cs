using System.ComponentModel.DataAnnotations;
using uit_learn_backend.Attributes;
using uit_learn_backend.Models;

namespace uit_learn_backend.Dtos
{
    public class CourseDto
    {

        [Code]
        public string? Code { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string? Name { get; set; }

        public string? Description { get; set; } = "";
        public bool? IsPublished { get; set; } = false;

        [Required]
        public IFormFile? Image { get; set; }

        public string? Thumb { get; set; }

        public DateTime? DateCreated
        { get; set; } = DateTime.UtcNow;

        public DateTime? DateUpdated { get; set; } = DateTime.UtcNow;

        [Required]
        public string? SubjectCode { get; set; }

        public CourseDto()
        {
        }

        public CourseDto(Course? course)
        {
            Name = course?.Name;
            Description = course?.Description;
            Code = course?.Code;
            IsPublished = course?.IsPublished;
            Thumb = course?.Thumb;
            DateCreated = course?.CreatedAt;
            DateUpdated = course?.UpdatedAt;
            SubjectCode = course?.SubjectCode;
        }
    }
}