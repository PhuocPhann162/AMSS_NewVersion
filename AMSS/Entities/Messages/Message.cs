using AMSS.Entities.ChatRooms;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Entities.Messages
{
    public partial class Message : BaseModel<Guid>
    {
        [Column(TypeName = "nvarchar(MAX)")]
        public string Content { get; set; } 
        public MessageType Type { get; set; } 
        public Guid ChatRoomId { get; set; }
        public DateTime SentAt { get; set; } 
        public bool IsEdited { get; set; }
        public bool IsDeleted { get; set; } = false;

        [ForeignKey("Sender")]
        public string SenderId { get; set; }

        public virtual ApplicationUser Sender { get; set; } 
        public virtual ChatRoom ChatRoom { get; set; } 
    }

    public enum MessageType
    {
        Text = 1,
        Image = 2,
        File = 3,
        System = 4
    }
}
