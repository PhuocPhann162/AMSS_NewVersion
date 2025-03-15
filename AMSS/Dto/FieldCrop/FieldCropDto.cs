using AMSS.Dto.Crop;
using AMSS.Dto.Field;

namespace AMSS.Dto.FieldCrop
{
    public class FieldCropDto
    {
        public Guid FieldId { get; set; }
        public FieldDto Field { get; set; }

        public Guid CropId { get; set; }
        public CropDto Crop { get; set; }
    }
}
