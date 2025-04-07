using AMSS.Services.IService;
using AMSS.Services.IService.IGeneratePdf;
using AMSS.Utility;
using DinkToPdf;
using System.Data;

namespace AMSS.Services.GeneratePdf
{
    public class GeneratePdfService : IGeneratePdfService
    {
        private readonly ILogger<GeneratePdfService> _logger;
        private readonly IPdfConverter _converter;
        private readonly IBlobService _blobService;
        public GeneratePdfService(ILogger<GeneratePdfService> logger, IPdfConverter converter, IBlobService blobService)
        {
            _logger = logger;
            _converter = converter;
            _blobService = blobService;
        }

        private async Task<string> ConvertAndUploadBlobFileAsync
            (string html, string fileName, Guid modelId)
        {
            var strBase64 = Convert.ToBase64String(_converter.ConvertWithPage(html, Orientation.Portrait));
            var bytes = Convert.FromBase64String(strBase64);
            using var stream = new MemoryStream(bytes);
            var file = new FormFile(stream, 0, bytes.Length, fileName, fileName);
            var result = await _blobService.UploadBlob(fileName, SD.SD_Storage_Container, file);
            if (result == null)
            {
                return string.Empty;
            }
            return result;
        }
    }
}
