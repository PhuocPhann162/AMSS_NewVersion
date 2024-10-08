﻿using AMSS.Models.Dto.CropType;
using AMSS.Models.Dto.Field;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models.Dto.Crop
{
    public class CreateCropDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Cycle { get; set; }

        public bool? Edible { get; set; }

        public string? Soil { get; set; }

        public string? Watering { get; set; }

        public string? Maintenance { get; set; }

        public int? HardinessZone { get; set; }

        public bool? Indoor { get; set; }

        public string? Propogation { get; set; }

        public string? CareLevel { get; set; }

        public string? GrowthRate { get; set; }

        public string? Description { get; set; }

        public double? CultivatedArea { get; set; }

        public DateTime? PlantedDate { get; set; }

        public DateTime? ExpectedDate { get; set; }

        public int? Quantity { get; set; }

        public Guid? CropTypeId { get; set; }

        public IFormFile? File { get; set; }
    }
}
