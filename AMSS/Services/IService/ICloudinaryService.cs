using AMSS.Dto.Responses;

namespace AMSS.Services.IService
{
    public interface ICloudinaryService
    {
        Task<UploadCloudinaryResponse> UploadImageAsync(IFormFile file);
        Task<bool> DeleteImageAsync(string publicId);
    }
}
