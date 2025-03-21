﻿using System.ComponentModel.DataAnnotations;

namespace AMSS.Dto.Farm
{
    public class CreateFarmDto
    {
        [Required]
        public string Name { get; set; }
        public double Area { get; set; }
        [Required]
        public Guid LocationId { get; set; }

        public string OwnerName { get; set; }

        [Required]
        public Guid PolygonAppId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
