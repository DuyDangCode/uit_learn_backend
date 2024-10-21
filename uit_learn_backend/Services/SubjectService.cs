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
            IFormFile? image = newSubject.Image;
            ImageUploadResult uploadImageResult = await _photoRepo.Upload(image);
            if (uploadImageResult.Error != null)
            {
                return false;
            }
            var subject = new Subject
            {
                Name = newSubject.Name,
                Description = newSubject.Description,
                Thumb = uploadImageResult.SecureUrl.AbsoluteUri,
                ImageCode = uploadImageResult.PublicId,
            };
            await _subjectRepo.Create(subject);
            return true;
        }

        public async Task<List<Subject>> GetAllPublished()
        {
            return await _subjectRepo.Find();
        }
    }
}
