using AMSS.Entities;
using AMSS.Models.Commodities;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models.Suppliers
{
    public partial class Supplier : BaseModel<Guid>
    {
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string ContactName { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string PhoneCode { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Address { get; set; }
        public virtual ICollection<Commodity> Commodities { get; set; }
    }
}
