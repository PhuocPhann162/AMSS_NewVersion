using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AMSS.Models
{
    public abstract class BaseModel
    {
        [Column("CreatedAt", TypeName = "datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [Column("UpdatedAt", TypeName = "datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedAt { get; set; }
    }

    public abstract class BaseModel<TPrimaryKeyType> : BaseModel
    {
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TPrimaryKeyType Id { get; set; }
    }
}
