﻿using System.ComponentModel.DataAnnotations;

namespace AMSS.Dto.Location
{
    public class CreateLocationDto
    {
        [Required]
        [StringLength(500)]
        public string Address { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        public string CountryCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Road { get; set; }
        public string PostCode { get; set; }

    }
}
