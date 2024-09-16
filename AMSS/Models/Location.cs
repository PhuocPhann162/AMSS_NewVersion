﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models
{
    public class Location : BaseModel<Guid>
    {
        [Required]
        [MaxLength(500)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90 degrees.")]
        public float? Lat { get; set; } = 0;

        [Required]
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180 degrees.")]
        public float? Lng { get; set; } = 0;
        public string? CountryCode { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? District { get; set; }
        public string? Road { get; set; }
        public string? PostCode { get; set; }
    }
}
