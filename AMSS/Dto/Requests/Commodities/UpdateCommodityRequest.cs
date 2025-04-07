using AMSS.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AMSS.Dto.Requests.Commodities
{
    public class UpdateCommodityRequest
    {
        [Required(ErrorMessage = "Commodity name is required.")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Special Tag is required.")]
        public string SpecialTag { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please select file to upload")]
        [JsonPropertyName("File")]
        public IFormFile File { get; set; }

        [Required(ErrorMessage = "Please select expiration date")]
        public DateTime ExpirationDate { get; set; }

        public Guid SupplierId { get; set; }

        public Guid CropId { get; set; }

        public string SupplierName { get; set; }

        public string CropName { get; set; }

        public CommodityStatus Status { get; set; }
    }
}
