using AMSS.Models.Dto.Crop;
using AMSS.Models.Dto.Field;

namespace AMSS.Models.Dto.FieldCrop
{
    public class FieldCropDto
    {
        public Guid FieldId { get; set; }
        public FieldDto Field { get; set; }

        public Guid CropId { get; set; }
        public CropDto Crop { get; set; }
    }
}
