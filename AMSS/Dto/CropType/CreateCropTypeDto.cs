using System.ComponentModel.DataAnnotations;

namespace AMSS.Dto.CropType
{
    public class CreateCropTypeDto
    {
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }

        public string Type { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
