using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Entities.CareLogs
{
    public partial class CareLog : BaseModel<Guid>
    {
        public CareLogType Type { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid CropId { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid FieldId { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        public string CreatedById { get; set; }

        public virtual Crop Crop { get; set; }
        public virtual Field Field { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
    }

    public enum CareLogType
    {
        Sowing,
        Watering,
        Fertilizing,
        SprayingPesticides,
        Pruning,
        Harvesting,
        Other,
    }
}
