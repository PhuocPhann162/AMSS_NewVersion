using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AMSS.Entities
{
    public class SeriesMetric : BaseModel<Guid>
    {
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string Code { get; set; }

        public virtual ICollection<SocialMetric> SocialMetrics { get; set; }
    }
}
