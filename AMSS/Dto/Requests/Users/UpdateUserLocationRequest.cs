using System.ComponentModel.DataAnnotations;

namespace AMSS.Dto.Requests.Users
{
    public class UpdateUserLocationRequest
    {
        [MaxLength(255, ErrorMessage = "Address cannot be longer than 255 characters.")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Latitude is required.")]
        [Range(typeof(float), "-90", "90", ErrorMessage = "Latitude must be between -90 and 90.")]
        public float Lat { get; set; }

        [Required(ErrorMessage = "Longitude is required.")]
        [Range(typeof(float), "-180", "180", ErrorMessage = "Longitude must be between -180 and 180.")]
        public float Lng { get; set; }
    }
}
