using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models
{
    public class Province : BaseModel<Guid>
    {
        [Required]
        [MaxLength(5)]
        [Column(TypeName = "nvarchar(5)")]
        public string? Code { get; set; }
        
        [Required]
        [MaxLength(5)]
        [Column(TypeName = "nvarchar(5)")]
        public string? CountryCode { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string? Name { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string? Category { get; set; }


        public Guid? CountryContinentId { get; set; }
        [ForeignKey("CountryContinentId")]
        public virtual CountryContinent? CountryContinent { get; set; } 
    }
}
