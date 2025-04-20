using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Entities.Locations
{
    public partial class Location : BaseModel<Guid>
    {
        [Column(TypeName = "nvarchar(MAX)")]
        public string Address { get; set; }

        [Range(-90, 90)]
        [Column(TypeName = "float")]
        public float Lat { get; set; }

        [Range(-180, 180)]
        [Column(TypeName = "float")]
        public float Lng { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string CountryCode { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string City { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string State { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string District { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Road { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string PostCode { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
