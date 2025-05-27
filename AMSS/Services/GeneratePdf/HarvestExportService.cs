using AMSS.Dto.Crop;
using AMSS.Entities;
using AMSS.Services.IService.IGeneratePdf;
using System.Text;

namespace AMSS.Services.GeneratePdf
{
    public class HarvestExportService : BaseService, IHarvestExportService
    {
        private readonly ILogger<HarvestExportService> _logger;
        private readonly IGeneratePdfService _pdfService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HarvestExportService(
            ILogger<HarvestExportService> logger,
            IGeneratePdfService pdfService,
            IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _pdfService = pdfService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<APIResponse<string>> GenerateHarvestExportPdfAsync(HarvestExportData data)
        {
            try
            {
                // Read template
                string templatePath = Path.Combine(_webHostEnvironment.WebRootPath, "PdfTemplates", "HarvestExportTemplate.html");
                string template = await File.ReadAllTextAsync(templatePath);

                // Generate tables HTML
                string plantsTable = GeneratePlantsTable(data.Plants);
                string seedsTable = GenerateSeedsTable(data.Seeds);

                // Replace placeholders
                string html = template
                    .Replace("{{GeneratedDate}}", data.GeneratedDate.ToString("dd/MM/yyyy HH:mm"))
                    .Replace("{{PlantsTable}}", plantsTable)
                    .Replace("{{SeedsTable}}", seedsTable)
                    .Replace("{{CurrentYear}}", DateTime.Now.Year.ToString());

                // Generate PDF
                string fileName = $"HarvestExport_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                var pdfUrl = await _pdfService.ConvertAndUploadBlobFileAsync(html, fileName, Guid.NewGuid());
                return BuildSuccessResponseMessage(pdfUrl);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating harvest export PDF");
                throw;
            }
        }

        private string GeneratePlantsTable(List<HarvestPlant> plants)
        {
            var sb = new StringBuilder();
            foreach (var plant in plants)
            {
                sb.AppendLine("<tr>");
                sb.AppendLine($"<td>{plant.PlantName}</td>");
                sb.AppendLine($"<td>{plant.Variety}</td>");
                sb.AppendLine($"<td>{plant.PlantingDate:dd/MM/yyyy}</td>");
                sb.AppendLine($"<td>{plant.ExpectedHarvestDate:dd/MM/yyyy}</td>");
                sb.AppendLine($"<td>{plant.Quantity}</td>");
                sb.AppendLine($"<td>{plant.Status}</td>");
                sb.AppendLine("</tr>");
            }
            return sb.ToString();
        }

        private string GenerateSeedsTable(List<HarvestSeed> seeds)
        {
            var sb = new StringBuilder();
            foreach (var seed in seeds)
            {
                sb.AppendLine("<tr>");
                sb.AppendLine($"<td>{seed.SeedName}</td>");
                sb.AppendLine($"<td>{seed.Variety}</td>");
                sb.AppendLine($"<td>{seed.StorageDate:dd/MM/yyyy}</td>");
                sb.AppendLine($"<td>{seed.ExpiryDate:dd/MM/yyyy}</td>");
                sb.AppendLine($"<td>{seed.Quantity}</td>");
                sb.AppendLine($"<td>{seed.Status}</td>");
                sb.AppendLine("</tr>");
            }
            return sb.ToString();
        }
    }
} 