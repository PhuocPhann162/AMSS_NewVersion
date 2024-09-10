using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using AMSS.Enums;
using System.Text.Json.Serialization;

namespace AMSS.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Password { get; set; } = string.Empty;

        [MaxLength(400)]
        [Column(TypeName = "nvarchar(400)")]
        public string? StreetAddress { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string? City { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string? State { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string? Country { get; set; }

        [MaxLength(1000)]
        [Column(TypeName = "nvarchar(1000)")]
        public string? Avatar { get; set; }

        [MaxLength(1000)]
        [Column(TypeName = "nvarchar(1000)")]
        public string? RefreshToken { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        [NotMapped]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Role? Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
