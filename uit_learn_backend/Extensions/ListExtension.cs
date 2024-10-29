using uit_learn_backend.Dtos;
using uit_learn_backend.Models;

namespace uit_learn_backend.Extensions
{
    public static class ListExtension
    {
        public static List<SubjectDto> ConvertToSubjectDtoList(this List<Subject> subjects)
            => subjects.Select(subject => new SubjectDto(subject))
            .ToList();
        public static List<CourseDto> ConvertToCourseDtoList(this List<Course> courses)
                    => courses.Select(course => new CourseDto(course))
                    .ToList();
    }
}
