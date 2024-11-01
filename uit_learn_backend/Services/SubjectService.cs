using CloudinaryDotNet.Actions;
using System.Text;
using uit_learn_backend.Core;
using uit_learn_backend.Dtos;
using uit_learn_backend.Models;
using uit_learn_backend.Repos;

namespace uit_learn_backend.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepo _subjectRepo;
        private readonly IPhotoRepo _photoRepo;
        public SubjectService(ISubjectRepo subjectRepo, IPhotoRepo photoRepo)
        {
            _subjectRepo = subjectRepo;
            _photoRepo = photoRepo;
        }

        public async Task<Result<object>> Create(SubjectDto newSubject)
        {
            var codeSubject = newSubject.Code;
            if (string.IsNullOrEmpty(codeSubject))
            {
                var i = 5;
                var numberOfChars = 3;
                do
                {
                    if (i == 0)
                    {
                        numberOfChars++;
                        i = 5;
                    }
                    if (numberOfChars > 10) throw new Exception("Cant create code");
                    codeSubject = CreateCode(newSubject, numberOfChars);
                    i--;
                } while (await _subjectRepo.FindByCode(codeSubject) is not null);

            }
            else
            {
                Subject foundSubject = await _subjectRepo.FindByCode(codeSubject);
                if (foundSubject is not null) return Result<object>.Error("Product is exist");
            }

            IFormFile? image = newSubject?.Image;
            ImageUploadResult uploadImageResult = await _photoRepo.Upload(image);
            if (uploadImageResult.Error is not null) return Result<object>.Error("Image update fail");

            var subject = new Subject
            {
                Name = newSubject?.Name,
                Description = newSubject?.Description,
                Thumb = uploadImageResult.SecureUrl.AbsoluteUri,
                ImageCode = uploadImageResult.PublicId,
                Code = codeSubject,
                IsPublished = newSubject?.IsPublished ?? false
            };
            await _subjectRepo.Create(subject);
            return Result<object>.Success(subject);
        }

        public string CreateCode(SubjectDto subject, int numberOfChars = 3)
        {
            var stringBuilder = new StringBuilder();
            var words = subject.Name?.Split(" ");

            for (int i = 0; i < words?.Length; i++)
            {
                string? word = words[i];
                stringBuilder.Append(word[0]);
            }

            var ran = new Random();
            for (var i = 0; i < numberOfChars; i++)
            {
                stringBuilder.Append((char)ran.Next(48, 57));
            }
            return stringBuilder.ToString();
        }

        public async Task<Result<object>> Delete(string code)
        {
            Subject foundSubject = await _subjectRepo.FindByCode(code);
            if (foundSubject == null) return Result<object>.Error(code);
            await _subjectRepo.Delete(code);
            return Result<object>.Success(foundSubject);
        }

        public async Task<Result<Subject>> Get(string code)
        {
            return Result<Subject>.Success(await _subjectRepo.FindByCode(code));
        }

        public Task<List<Subject>> GetAll(int page, int limit = 10)
        {
            var skip = (page - 1) * limit;
            return _subjectRepo.FindAll(limit, skip);
        }

        public Task<List<Subject>> GetAllPublished(int page, int limit = 10)
        {
            var skip = (page - 1) * limit;
            return _subjectRepo.FindAllPublished(limit, skip);
        }

        public Task<List<Subject>> GetAllUnPublished(int page, int limit = 10)
        {
            var skip = (page - 1) * limit;
            return _subjectRepo.FindAllUnPublised(limit, skip);
        }

        public async Task<Result<object>> Update(string code, SubjectDto newSubject)
        {
            Subject foundSubject = await _subjectRepo.FindByCode(code);

            if (foundSubject == null)
                return Result<object>.Error("Subject not found");
            await _subjectRepo.Update(code, new Subject
            {
                Name = newSubject.Name,
                Description = newSubject.Description,
                Thumb = foundSubject.Thumb,
                ImageCode = foundSubject.ImageCode,
                IsPublished = newSubject.IsPublished,
                Code = newSubject.Code
            }
            );
            return Result<object>.Success(newSubject);
        }
    }
}
