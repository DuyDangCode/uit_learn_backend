using CloudinaryDotNet.Actions;
using System.Text;
using uit_learn_backend.Core;
using uit_learn_backend.Dtos;
using uit_learn_backend.Models;
using uit_learn_backend.Repos;

namespace uit_learn_backend.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepo _courseRepo;
        private readonly IPhotoRepo _photoRepo;
        private readonly ISubjectRepo _subjectRepo;


        public CourseService(ICourseRepo courseRepo, IPhotoRepo photoRepo, ISubjectRepo subjectRepo)
        {
            _courseRepo = courseRepo;
            _photoRepo = photoRepo;
            _subjectRepo = subjectRepo;
        }

        public string CreateCode(CourseDto course, int numberOfChars, double ratio = 0.8)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(course.SubjectCode);
            stringBuilder.Append("-");
            var ran = new Random();

            //part2 of code has two sub part
            //sub part 1 only contain character
            //sub part 2 only contain number
            var numberOfPart1 = Math.Round(numberOfChars * ratio);
            var numberOfPart2 = numberOfChars - numberOfPart1;
            for (var i = 0; i < numberOfPart1; i++)
            {
                stringBuilder.Append((char)ran.Next(65, 90));
            }
            for (var i = 0; i < numberOfPart2; i++)
            {
                stringBuilder.Append((char)ran.Next(48, 57));
            }
            return stringBuilder.ToString();
        }


        public async Task<Result<object>> Create(CourseDto newCourse)
        {
            var subjectCode = newCourse.SubjectCode;
            if (string.IsNullOrEmpty(subjectCode)) return Result<object>.Error("Subject code is required");

            var foundSubject = await _subjectRepo.FindByCode(subjectCode);
            if (foundSubject is null) return Result<object>.Error("Subject code is not exist");


            var codeCourse = newCourse.Code;
            if (string.IsNullOrEmpty(codeCourse))
            {
                var i = 5;
                var numberOfChars = 8;
                do
                {
                    if (i == 0)
                    {
                        numberOfChars++;
                        i = 5;
                    }
                    if (numberOfChars > 15) throw new Exception("Cant create code");
                    codeCourse = CreateCode(newCourse, numberOfChars);
                } while (await _courseRepo.FindByCode(newCourse.Code) is not null);

            }
            else
            {
                var foundCourse = await _courseRepo.FindByCode(newCourse.Code);
                if (foundCourse is not null)
                    return Result<object>.Error("Course is exist");
            }
            IFormFile? image = newCourse.Image;
            ImageUploadResult uploadImageResult = await _photoRepo.Upload(image);
            if (uploadImageResult.Error is not null) return Result<object>.Error("Image update fail");

            var course = new Course
            {
                Name = newCourse?.Name,
                Description = newCourse?.Description,
                Thumb = uploadImageResult.SecureUrl.AbsoluteUri,
                Code = codeCourse,
                IsPublished = newCourse?.IsPublished ?? false,
                SubjectCode = newCourse?.SubjectCode,
                ImageCode = uploadImageResult.PublicId,
            };
            await _courseRepo.Create(course);

            return Result<object>.Success(course);
        }

        public async Task<Result<object>> Delete(string code)
        {
            bool result = await _courseRepo.Delete(code);
            if (!result) return Result<object>.Error(code);
            return Result<object>.Success(result);
        }

        public async Task<Result<Course>> Get(string code)
        {
            Course foundCourse = await _courseRepo.FindById(code);
            if (foundCourse == null) return Result<Course>.Error("Not found course");
            return Result<Course>.Success(foundCourse);
        }

        public Task<List<Course>> GetAll(int page, int limit = 10)
        {
            return _courseRepo.FindAll(limit, (page - 1) * limit);
        }

        public Task<List<Course>> GetAllPublished(int page, int limit = 10)
        {
            return _courseRepo.FindAllPublished(limit, (page - 1) * limit);
        }

        public Task<List<Course>> GetAllUnPublished(int page, int limit = 10)
        {
            return _courseRepo.FindAllUnPublised(limit, (page - 1) * limit);
        }

        public async Task<Result<object>> Update(string code, CourseDto newCourse)
        {
            Course foundCourse = await _courseRepo.FindById(code);
            if (foundCourse == null)
                return Result<object>.Error("Course is not exist");
            return Result<object>.Success(_courseRepo.Update(code, new Course
            {
                Name = newCourse.Name,
                Description = newCourse.Description,
                Thumb = newCourse.Thumb,
                Code = newCourse.Code,
                IsPublished = newCourse.IsPublished,
                SubjectCode = newCourse.SubjectCode
            }));

        }

    }
}
