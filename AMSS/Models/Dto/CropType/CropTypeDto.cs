﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AMSS.Models.Dto.Crop;

namespace AMSS.Models.Dto.CropType
{
    public class CropTypeDto
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        public string Type { get; set; }

        public IEnumerable<CropDto> Crops { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
