using AMSS.Dto.Crop;
using AMSS.Dto.Field;
using AMSS.Dto.User;
using AMSS.Entities.CareLogs;
using System.ComponentModel.DataAnnotations;

namespace AMSS.Dto.Requests.CareLogs
{
    public class CreateCareLogRequest
    {
        [Required(ErrorMessage = "Care log type is required.")]
        public CareLogType Type { get; set; }

        [Required(ErrorMessage = "Care log type is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Care log type is required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Care log type is required.")]
        public Guid CropId { get; set; }

        [Required(ErrorMessage = "Care log type is required.")]
        public Guid FieldId { get; set; }
    }
}
