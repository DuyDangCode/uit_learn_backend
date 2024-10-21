using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using uit_learn_backend.Config;

namespace uit_learn_backend.Dbs
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;
        public CloudinaryService(IOptions<CloudinaryConfig> config)
        {
            _cloudinary = new Cloudinary(new Account(config.Value.CouldName,
                                                     config.Value.ApiKey,
                                                     config.Value.ApiSecret));
        }

        public Cloudinary Database() => _cloudinary;
    }
}
