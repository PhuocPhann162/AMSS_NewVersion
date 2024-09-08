using AMSS.Models.Dto.Crop;
using System.ComponentModel.DataAnnotations;

namespace AMSS.Models.Dto.CropType
{
    public class CreateCropTypeDto
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public string Type { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
