using AMSS.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AMSS.Models.Dto.Auth
{
    public class RegistrationRequestDto
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [MaxLength(45)]
        public string FullName { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        [StringLength(500)]
        public string? Avatar { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(32)]
        public string Password { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Role? Role { get; set; }
    }
}
