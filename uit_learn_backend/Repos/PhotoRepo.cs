using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using uit_learn_backend.Dbs;

namespace uit_learn_backend.Repos
{
    public class PhotoRepo : IPhotoRepo
    {
        private readonly Cloudinary _cloudinary;
        public PhotoRepo(ICloudinaryService cloudinaryService)
        {
            _cloudinary = cloudinaryService.Database();
        }

        public Task<DeletionResult> Deletion(string fileId)
        {
            var deletionParams = new DeletionParams(fileId);
            return _cloudinary.DestroyAsync(deletionParams);
        }

        public async Task<ImageUploadResult> Upload(IFormFile? file)
        {
            var uploadResult = new ImageUploadResult();
            if (file?.Length <= 0) return uploadResult;

            using var stream = file?.OpenReadStream();
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file?.FileName, stream),
            };

            uploadResult = await _cloudinary.UploadAsync(uploadParams);
            return uploadResult;
        }
    }
}
