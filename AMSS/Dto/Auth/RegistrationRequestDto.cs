using AMSS.Enums;
using System.ComponentModel.DataAnnotations;

namespace AMSS.Dto.Auth
{
    public class RegistrationRequestDto
    {
        [Required]
        [EmailAddress]
        [StringLength(255, ErrorMessage = "Email cannot be longer than 255 characters.")]
        public string UserName { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "ContactName cannot be longer than 150 characters.")]
        public string ContactName { get; set; }

        [StringLength(150, ErrorMessage = "CompanyName cannot be longer than 150 characters.")]
        public string CompanyName { get; set; }

        [StringLength(10)]
        public string ProvinceCode { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "PhoneCode cannot be longer than 10 characters.")]
        [RegularExpression(@"^\+\d+$", ErrorMessage =
            "Phone Code only accepts number 0-9 and start with plus sign.")]
        public string PhoneCode { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "PhoneNumber cannot be longer than 15 characters.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "PhoneNumber allowing numbers only.")]
        public string PhoneNumber { get; set; }

        [StringLength(255, ErrorMessage = "Address cannot be longer than 255 characters.")]
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Required]
        [StringLength(2)]
        public string Country { get; set; }

        [StringLength(500)]
        public string Avatar { get; set; }

        [MinLength(8)]
        [MaxLength(32)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Latitude is required.")]
        [Range(typeof(float), "-90", "90", ErrorMessage = "Latitude must be between -90 and 90.")]
        public float Lat { get; set; }

        [Required(ErrorMessage = "Longitude is required.")]
        [Range(typeof(float), "-180", "180", ErrorMessage = "Longitude must be between -180 and 180.")]
        public float Lng { get; set; }

        public Role Role { get; set; }
    }
}
