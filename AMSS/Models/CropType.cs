using AMSS.Models.Dto.Crop;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models
{
    public class CropType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string? Name { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? Code { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? Type { get; set; }

        public DateTime? CreatedAt{ get; set; } = DateTime.Now;
        public DateTime? UpdatedAt{ get; set; }
        public DateTime? DeletedAt{ get; set; }

        public virtual ICollection<Crop> Crops { get; set; } = new List<Crop>();
    }
}
