using AMSS.Dto.Crop;
using AMSS.Dto.Field;
using AMSS.Dto.User;
using AMSS.Entities.CareLogs;

namespace AMSS.Dto.CareLog
{
    public class CareLogDto
    {
        public Guid Id { get; set; }
        public CareLogType Type { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public Guid CropId { get; set; }

        public Guid FieldId { get; set; }

        public string CreatedById { get; set; }

        public virtual CropDto Crop { get; set; }
        public virtual FieldDto Field { get; set; }
        public virtual UserDto CreatedBy { get; set; }

    }
}
