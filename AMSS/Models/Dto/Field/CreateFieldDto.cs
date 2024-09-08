using System.ComponentModel.DataAnnotations;

namespace AMSS.Models.Dto.Field
{
    public class CreateFieldDto
    {
        [Required]
        public string Name { get; set; }

        public double Area { get; set; }

        public string? Status { get; set; }

        [Required]
        public int FarmId { get; set; }
        [Required]
        public int LocationId { get; set; }

        [Required]
        public int PolygonAppId { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
