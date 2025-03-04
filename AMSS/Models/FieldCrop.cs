using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models
{
    public class FieldCrop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid FieldId { get; set; }
        [ForeignKey("FieldId")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.ClientSetNull)]
        public virtual Field Field { get; set; } 

        public Guid CropId { get; set; }
        [ForeignKey("CropId")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.ClientSetNull)]
        public virtual Crop Crop { get; set; } 
    }
}
