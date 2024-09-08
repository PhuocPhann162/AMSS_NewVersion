using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models
{
    public class SoilQuality
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime InfoTime { get; set; }
        public float Chlorophyll { get; set; }
        public float Iron { get; set; }
        public float Nitrate { get; set; }
        public float Phyto { get; set; }
        public float Oxygen { get; set; }
        public float PH { get; set; }
        public float Phytoplankton { get; set; }
        public float Silicate { get; set; }
        public float Salinity { get; set; }
        public int SoilMoisture { get; set; }
        public int SoilMoisture10cm { get; set; }
        public int SoilMoisture40cm { get; set; }
        public int SoilMoisture100cm { get; set; }
        public int SoilTemperature { get; set; }
        public int SoilTemperature10cm { get; set; }
        public int SoilTemperature40cm { get; set; }
        public int SoilTemperature100cm { get; set; }

        public int? FieldId { get; set; }
        [ForeignKey("FieldId")]
        [ValidateNever]
        public Field Field { get; set; }
    }
}
