namespace AMSS.Services.IService.IGeneratePdf
{
    public interface IGeneratePdfService
    {
        Task<string> ConvertAndUploadBlobFileAsync(string html, string fileName, Guid modelId);
    }
}
