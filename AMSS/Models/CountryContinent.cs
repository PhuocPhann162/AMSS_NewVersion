using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models
{
    public class CountryContinent : BaseModel<Guid>
    {
        [Range(0, float.MaxValue)]
        public float Co2Rate { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string? ContinentCode { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string? ContinentName { get; set; }

        [Required]
        [MaxLength(5)]
        [Column(TypeName = "nvarchar(5)")]
        public string? CountryCode { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string? CountryName { get; set; }

        public virtual ICollection<Province> Provinces { get; set; } = new List<Province>();
    }
}
