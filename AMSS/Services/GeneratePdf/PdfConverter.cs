using AMSS.Services.IService.IGeneratePdf;
using DinkToPdf;
using DinkToPdf.Contracts;

namespace AMSS.Services.GeneratePdf
{
    public class PdfConverter : IPdfConverter
    {
        private readonly IConverter _converter;
        public PdfConverter(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] Convert(string htmlContent, Orientation orientation = Orientation.Portrait)
        {
            var doc = new HtmlToPdfDocument
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = orientation,
                    PaperSize = PaperKind.A4
                },
                Objects =
                {
                    new ObjectSettings
                    {
                        HtmlContent = htmlContent,
                        UseExternalLinks = true,
                        UseLocalLinks = true,
                        WebSettings =
                        {
                            DefaultEncoding = "utf-8"
                        }
                    }
                }
            };

            return _converter.Convert(doc);
        }

        public byte[] ConvertToPdfNoMargin(string htmlContent, Orientation orientation = Orientation.Portrait)
        {
            var doc = new HtmlToPdfDocument
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = orientation,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings(0,0,0,0)
                },
                Objects =
                {
                    new ObjectSettings
                    {
                        HtmlContent = htmlContent,
                        UseExternalLinks = true,
                        UseLocalLinks = true,
                        WebSettings =
                        {
                            DefaultEncoding = "utf-8"
                        }
                    }
                }
            };

            return _converter.Convert(doc);
        }

        public byte[] ConvertWithPage(string htmlContent, Orientation orientation = Orientation.Portrait)
        {
            var doc = new HtmlToPdfDocument
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = orientation,
                    PaperSize = PaperKind.A4
                },
                Objects =
                {
                    new ObjectSettings
                    {
                        HtmlContent = htmlContent,
                        UseExternalLinks = true,
                        UseLocalLinks = true,
                        WebSettings =
                        {
                            DefaultEncoding = "utf-8"
                        },
                        PagesCount = true,
                        FooterSettings = { FontSize = 6, Right = "Page [page]/[toPage]", Line = false, Spacing = 2.812 }
                    }
                }
            };

            return _converter.Convert(doc);
        }
    }
}
