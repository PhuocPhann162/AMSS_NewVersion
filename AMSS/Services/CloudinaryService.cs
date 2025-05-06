using AMSS.Dto.Responses;
using AMSS.Infrastructures.Configurations;
using AMSS.Services.IService;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;

namespace AMSS.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;
        private readonly CloudinarySettings _cloudinaryConfig;

        public CloudinaryService(IOptionsMonitor<CloudinarySettings> cloudinaryConfig)
        {
            _cloudinaryConfig = cloudinaryConfig.CurrentValue;
            var acc = new Account(
                _cloudinaryConfig.CloudName,
                _cloudinaryConfig.ApiKey,
                _cloudinaryConfig.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
            _cloudinary.Api.Secure = true;
        }

        public async Task<UploadCloudinaryResponse> UploadImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0) return null!;

            await using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Transformation = new Transformation().Quality("auto").FetchFormat("auto")
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return new UploadCloudinaryResponse
                {
                    Url = uploadResult.SecureUrl.AbsoluteUri,
                    PublicId = uploadResult.PublicId
                };
            }

            return null!;
        }

        public async Task<bool> DeleteImageAsync(string publicId)
        {
            var deletionParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deletionParams);
            return result.Result == "ok";
        }
    }
}
