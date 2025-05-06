using AMSS.Dto.CropType;
using AMSS.Dto.Field;
using System.ComponentModel.DataAnnotations;

namespace AMSS.Dto.Crop
{
    public class UpdateCropDto
    {
        public Guid Id { get; set; }

        [StringLength(500)]
        public string Icon { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public double CultivatedArea { get; set; }

        public DateTime PlantedDate { get; set; }

        public DateTime ExpectedDate { get; set; }

        public int Quantity { get; set; }

        public Guid FieldId { get; set; }

        public Guid CropTypeId { get; set; }

        public IFormFile File { get; set; }
    }
}
