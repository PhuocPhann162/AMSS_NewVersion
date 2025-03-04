using System.ComponentModel.DataAnnotations;

namespace AMSS.Models.Dto.Field
{
    public class CreateFieldDto
    {
        [Required]
        public string Name { get; set; }

        public double Area { get; set; }

        public string Status { get; set; }

        [Required]
        public Guid FarmId { get; set; }
        [Required]
        public Guid LocationId { get; set; }

        [Required]
        public Guid PolygonAppId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
