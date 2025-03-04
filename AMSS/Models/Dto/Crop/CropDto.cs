using System.ComponentModel.DataAnnotations;
using AMSS.Models.Dto.CropType;
using AMSS.Models.Dto.FieldCrop;

namespace AMSS.Models.Dto.Crop
{
    public class CropDto
    {
        public Guid Id { get; set; }

        [StringLength(1000)]
        public string Icon { get; set; }

        [Required]
        public string Name { get; set; }

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

        public string Description { get; set; }
        public double CultivatedArea { get; set; }

        public DateTime PlantedDate { get; set; }

        public DateTime ExpectedDate { get; set; }

        public int Quantity { get; set; } = 0;


        public Guid CropTypeId { get; set; }
        public IEnumerable<FieldCropDto> FieldCrops { get; set; } 

        public DateTime CreatedAt { get; set; }
    }
}
