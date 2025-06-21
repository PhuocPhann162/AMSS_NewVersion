using AMSS.Entities.ChatRoomUsers;
using AMSS.Entities.Messages;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Entities.ChatRooms
{
    public partial class ChatRoom : BaseModel<Guid>
    {
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; }

        public ChatRoomType Type { get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey(nameof(CreatedBy))]
        public string CreatedById { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual ICollection<ChatRoomUser> ChatRoomUsers { get; set; } 
        public virtual ICollection<Message> Messages { get; set; } 
    }

    public enum ChatRoomType
    {
        Private = 1,
        Group = 2,
        Public = 3
    }
}
