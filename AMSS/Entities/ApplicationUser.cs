using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using AMSS.Enums;
using System.Text.Json.Serialization;
using AMSS.Entities.Locations;

namespace AMSS.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(255)")]
        public string FullName { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Password { get; set; }

        [Column(TypeName = "nvarchar(400)")]
        public string StreetAddress { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string CountryCode { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string CountryName { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Avatar { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string ProvinceCode { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string ProvinceName { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string PhoneCode { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string RefreshToken { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsOnline { get; set; }

        public DateTime? LastSeen { get; set; }

        [NotMapped]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Role Role { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
    }
}
