using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Entities
{
#nullable enable
    public class FieldCrop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? FieldId { get; set; }
        [ForeignKey("FieldId")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.SetNull)]
        public virtual Field? Field { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? CropId { get; set; }
        [ForeignKey("CropId")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.SetNull)]
        public virtual Crop? Crop { get; set; }
    }
}
