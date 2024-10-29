using CloudinaryDotNet.Actions;

namespace uit_learn_backend.Repos
{
    public interface IPhotoRepo
    {
        Task<ImageUploadResult> Upload(IFormFile? file);
        Task<DeletionResult> Deletion(string fileId);
    }
}
