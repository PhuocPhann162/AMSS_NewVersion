using AMSS.Dto.Field;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Dto.SoilQuality
{
    public class SoilQualityDto
    {
        public DateTime InfoTime { get; set; } = DateTime.Now;
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

        public Guid FieldId { get; set; }
        public FieldDto Field { get; set; }
    }
}
