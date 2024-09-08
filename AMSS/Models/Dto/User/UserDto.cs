using AMSS.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AMSS.Models.Dto.User
{
    public class UserDto
    {
        public string Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? StreetAddress { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public bool IsActive { get; set; }

        public string RefreshToken { get; set; }

        [StringLength(500)]
        public string? Avatar { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Role? Role { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
    }
}
