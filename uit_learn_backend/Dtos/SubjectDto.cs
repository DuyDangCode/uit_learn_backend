using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using uit_learn_backend.Attributes;
using uit_learn_backend.Models;

namespace uit_learn_backend.Dtos
{
    public class SubjectDto
    {
        [Required]
        public string? Name { get; set; }

        [AllowNull]
        [IdString]
        public string? Id { get; set; }

        [DefaultValue("")]
        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public IFormFile? Image { get; set; }

        [Required]
        [NotNull]
        [StringLength(200)]
        public string? Code { get; set; }

        [DefaultValue(false)]
        public bool IsPublished { get; set; }

        public string? Thumb { get; set; }

        public SubjectDto()
        {

        }
        public SubjectDto(Subject subject)
        {
            Id = subject.Id;
            Name = subject.Name;
            Description = subject.Description;
            Code = subject.Code;
            Thumb = subject.Thumb;
            IsPublished = subject.IsPublished;
        }
    }
}
