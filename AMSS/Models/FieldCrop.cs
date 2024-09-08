using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Stripe;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Models
{
    public class FieldCrop
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int FieldId { get; set; }
        [ForeignKey("FieldId")]
        [ValidateNever]
        public Field Field { get; set; }

        public int CropId { get; set; }
        [ForeignKey("CropId")]
        [ValidateNever]
        public Crop Crop { get; set; }
    }
}
