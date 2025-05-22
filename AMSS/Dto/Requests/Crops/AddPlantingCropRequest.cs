using System.ComponentModel.DataAnnotations;

namespace AMSS.Dto.Requests.Crops
{
    public class AddPlantingCropRequest
    {
        [Required(ErrorMessage = "Crop Id  is required.")]
        public Guid CropId { get; set; }

        [Required(ErrorMessage = "Field Id  is required.")]
        public Guid FieldId { get; set; }

        [Required(ErrorMessage = "Quantity  is required.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Status  is required.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Unit  is required.")]
        public string Unit { get; set; }

        public string? Notes { get; set; }             
    }
}
