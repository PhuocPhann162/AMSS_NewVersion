using AMSS.Models.Dto.Crop;
using AMSS.Models.Dto.Field;

namespace AMSS.Models.Dto.FieldCrop
{
    public class FieldCropDto
    {
        public int? FieldId { get; set; }
        public FieldDto Field { get; set; }

        public int? CropId { get; set; }
        public CropDto Crop { get; set; }
    }
}
