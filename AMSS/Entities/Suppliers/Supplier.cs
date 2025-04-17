using AMSS.Entities;
using AMSS.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models.Suppliers
{
    [Index(nameof(SupplierRole))]
    [Index(nameof(Name))]
    [Index(nameof(ContactName))]
    [Index(nameof(CountryCode))]
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

        [Column(TypeName = "nvarchar(10)")]
        public string CountryCode { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string CountryName { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string ProvinceCode { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string ProvinceName { get; set; }

        public Role SupplierRole { get; set; }
    }
}
