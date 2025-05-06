using AMSS.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AMSS.Dto.Requests.Commodities
{
    public class CreateCommodityRequest
    {
        [Required(ErrorMessage = "Commodity name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public CommodityCategory Category { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please select file to upload.")]
        public IFormFile File { get; set; }

        [Required(ErrorMessage = "Please select expiration date.")]
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "Supplier Id is required.")]
        public Guid SupplierId { get; set; }

        [Required(ErrorMessage = "Crop Id is required.")]
        public Guid CropId { get; set; }

        public CommodityStatus Status { get; set; }
    }
}
