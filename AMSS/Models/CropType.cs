using AMSS.Models.Dto.Crop;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models
{
    public class CropType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }

        public string Type { get; set; }
        public virtual IEnumerable<Crop> Crops { get; set; } 

        public DateTime? CreatedAt{ get; set; }
        public DateTime? UpdatedAt{ get; set; }

    }
}
