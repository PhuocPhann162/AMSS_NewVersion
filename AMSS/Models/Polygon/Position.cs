using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models.Polygon
{
    public class Position
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90 degrees.")]
        public float Lat { get; set; } 

        [Required]
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180 degrees.")]
        public float Lng { get; set; }
        public bool IsDeleted { get; set; } 


        [Required]
        public Guid? PolygonAppId { get; set; } 
        [ForeignKey("PolygonAppId")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.ClientSetNull)]
        public virtual PolygonApp PolygonApp { get; set; } 

    }
}
