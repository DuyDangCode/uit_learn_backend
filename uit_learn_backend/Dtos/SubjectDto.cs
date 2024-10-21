using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace uit_learn_backend.Dtos
{
    public class SubjectDto
    {
        [Required]
        public string? Name { get; set; }
        [DefaultValue("")]
        [StringLength(500)]
        public string? Description { get; set; }
        [Required]
        public IFormFile? Image { get; set; }
        [Required]
        public string? Code { get; set; }
    }
}
