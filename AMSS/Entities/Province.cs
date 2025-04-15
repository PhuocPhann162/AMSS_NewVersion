using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Entities
{
    public class Province : BaseModel<Guid>
    {
        [MaxLength(5)]
        [Column(TypeName = "nvarchar(20)")]
        public string Code { get; set; }

        [MaxLength(5)]
        [Column(TypeName = "nvarchar(20)")]
        public string CountryCode { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string Category { get; set; }


        [ForeignKey("CountryContinentId")]
        public Guid? CountryContinentId { get; set; }

        public virtual CountryContinent CountryContinent { get; set; }
        public virtual ICollection<SocialMetric> SocialMetrics { get; set; }
    }
}
