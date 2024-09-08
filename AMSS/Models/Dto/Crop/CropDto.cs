using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using AMSS.Models.Dto.Field;
using AMSS.Models.Dto.CropType;
using AMSS.Models.Dto.FieldCrop;

namespace AMSS.Models.Dto.Crop
{
    public class CropDto
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string? Icon { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public string Cycle { get; set; }

        public bool Edible { get; set; }

        public string Soil { get; set; }

        public string Watering { get; set; }

        public string Maintenance { get; set; }

        public int HardinessZone { get; set; }

        public bool Indoor { get; set; }

        public string Propogation { get; set; }

        public string CareLevel { get; set; }

        public string GrowthRate { get; set; }

        public double CultivatedArea { get; set; }

        public DateTime PlantedDate { get; set; }

        public DateTime ExpectedDate { get; set; }


        public int Quantity { get; set; }

        public IEnumerable<FieldCropDto> FieldCrops { get; set; }

        public int? CropTypeId { get; set; }
        public virtual CropTypeDto CropType { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
