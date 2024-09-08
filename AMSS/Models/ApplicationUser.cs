using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using AMSS.Enums;
using System.Text.Json.Serialization;

namespace AMSS.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Password { get; set; }

        public string? StreetAddress { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        [StringLength(500)]
        public string? Avatar { get; set; }
        public string? RefreshToken { get; set; }

        public bool IsActive { get; set; } = true;

        [NotMapped]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Role? Role { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
