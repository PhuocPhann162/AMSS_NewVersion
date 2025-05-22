using System.ComponentModel.DataAnnotations;

namespace AMSS.Dto.Requests.Crops
{
    public class RemovePlantingCropRequest
    {
        [Required(ErrorMessage = "Field Id  is required.")]
        public Guid FieldId { get; set; }

        [Required(ErrorMessage = "Crop Id  is required.")]
        public Guid CropId { get; set; }
    }
}
