﻿using AMSS.Models.Commodities;
using AMSS.Models.Suppliers;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Entities
{
    public class Crop : BaseModel<Guid>
    {
        [Column(TypeName = "nvarchar(MAX)")]
        public string Icon { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Cycle { get; set; }

        public bool Edible { get; set; } = false;

        [Column(TypeName = "nvarchar(100)")]
        public string Soil { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Watering { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Maintenance { get; set; }

        public int HardinessZone { get; set; } = 0;

        public bool Indoor { get; set; } = false;

        [Column(TypeName = "nvarchar(100)")]
        public string Propagation { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string CareLevel { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string GrowthRate { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; }

        public double CultivatedArea { get; set; } = 0;

        public DateTime? PlantedDate { get; set; }

        public DateTime? ExpectedDate { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; } = 0;

        public string PublicImageId { get; set; }

        public Guid? SupplierId { get; set; }

        public Guid? CropTypeId { get; set; }
        [ForeignKey("CropTypeId")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.SetNull)]
        public virtual CropType CropType { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<FieldCrop> FieldCrops { get; set; }
        public virtual ICollection<Commodity> Commodities { get; set; } = new List<Commodity>();
    }
}
