using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Entities
{
#nullable enable
    public class CropType : BaseModel<Guid>
    {
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Type { get; set; }

        public virtual ICollection<Crop>? Crops { get; set; }
    }
}
