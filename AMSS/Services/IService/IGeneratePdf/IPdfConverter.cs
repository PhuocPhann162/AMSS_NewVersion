using DinkToPdf;

namespace AMSS.Services.IService.IGeneratePdf
{
    public interface IPdfConverter
    {
        byte[] Convert(string htmlContent, Orientation orientation = Orientation.Portrait);
        byte[] ConvertToPdfNoMargin(string htmlContent, Orientation orientation = Orientation.Portrait);
        byte[] ConvertWithPage(string htmlContent, Orientation orientation = Orientation.Portrait);
    }
}
