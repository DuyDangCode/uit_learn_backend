using CloudinaryDotNet.Actions;
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

        public CourseService(ICourseRepo courseRepo, IPhotoRepo photoRepo)
        {
            _courseRepo = courseRepo;
            _photoRepo = photoRepo;
        }

        public async Task<Result<object>> Create(CourseDto newCourse)
        {
            var foundedCourse = await _courseRepo.FindByCode(newCourse.Code);
            if (foundedCourse != null)
                return Result<object>.Error("Course is exist");

            IFormFile? image = newCourse.Image;
            ImageUploadResult uploadImageResult = await _photoRepo.Upload(image);
            if (uploadImageResult.Error != null) return Result<object>.Error("Image update fail");

            var course = new Course
            {
                Name = newCourse?.Name,
                Description = newCourse?.Description,
                Thumb = uploadImageResult.SecureUrl.AbsoluteUri,
                Code = newCourse?.Code,
                IsPublished = newCourse?.IsPublished ?? false,
                SubjectId = newCourse?.SubjectId,
                ImageCode = uploadImageResult.PublicId,
            };
            await _courseRepo.Create(course);

            return Result<object>.Success(course);
        }

        public async Task<Result<object>> Delete(string courseId)
        {
            bool result = await _courseRepo.Delete(courseId);
            if (!result) return Result<object>.Error(courseId);
            return Result<object>.Success(result);
        }

        public async Task<Result<Course>> Get(string courseId)
        {
            Course foundCourse = await _courseRepo.FindById(courseId);
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

        public async Task<Result<object>> Update(string subjectId, CourseDto newCourse)
        {
            Course foundCourse = await _courseRepo.FindById(subjectId);
            if (foundCourse == null)
                return Result<object>.Error("Course is not exist");
            return Result<object>.Success(_courseRepo.Update(subjectId, new Course
            {
                Name = newCourse.Name,
                Description = newCourse.Description,
                Thumb = newCourse.Thumb,
                Code = newCourse.Code,
                IsPublished = newCourse.IsPublished,
                SubjectId = newCourse.SubjectId,
            }));

        }

    }
}
