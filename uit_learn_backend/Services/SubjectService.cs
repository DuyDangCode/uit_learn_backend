using CloudinaryDotNet.Actions;
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

        public async Task<bool> Create(SubjectDto newSubject)
        {
            Subject foundSubject = await _subjectRepo.FindByCodeOrId(newSubject.Code, newSubject?.Id);
            if (foundSubject != null) return false;

            IFormFile? image = newSubject?.Image;
            ImageUploadResult uploadImageResult = await _photoRepo.Upload(image);
            if (uploadImageResult.Error != null) return false;

            var subject = new Subject
            {
                Id = newSubject?.Id,
                Name = newSubject?.Name,
                Description = newSubject?.Description,
                Thumb = uploadImageResult.SecureUrl.AbsoluteUri,
                ImageCode = uploadImageResult.PublicId,
                Code = newSubject?.Code,
                IsPublished = newSubject?.IsPublished ?? false
            };
            await _subjectRepo.Create(subject);
            return true;
        }

        public Task<Subject> Get(string subjectId)
        {
            return _subjectRepo.FindById(subjectId);
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

        public async Task<bool> Update(string subjectId, SubjectDto newSubject)
        {
            Subject foundSubject = await _subjectRepo.FindById(subjectId);

            if (foundSubject == null)
                return false;
            await _subjectRepo.Update(subjectId, new Subject
            {
                Name = newSubject.Name,
                Description = newSubject.Description,
                Thumb = foundSubject.Thumb,
                ImageCode = foundSubject.ImageCode,
                IsPublished = newSubject.IsPublished,
                Code = newSubject.Code
            }
            );
            return true;
        }
    }
}
