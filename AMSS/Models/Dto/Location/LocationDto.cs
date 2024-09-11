using System.ComponentModel.DataAnnotations;

namespace AMSS.Models.Dto.Location
{
    public class LocationDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(500)]
        public string? Address { get; set; }
        public float? Lat { get; set; }
        public float? Lng { get; set; }
        public string? CountryCode { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? District { get; set; }
        public string? Road { get; set; }
        public string? PostalCode { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
