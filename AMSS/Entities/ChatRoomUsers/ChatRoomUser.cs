using AMSS.Entities.ChatRooms;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMSS.Entities.ChatRoomUsers
{
    [Index(nameof(UserId), nameof(ChatRoomId))]
    public partial class ChatRoomUser : BaseModel<Guid>
    {
        public Guid ChatRoomId { get; set; }
        public ChatRoomRole Role { get; set; } 
        public bool IsActive { get; set; } = true;

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; } 
        public virtual ChatRoom ChatRoom { get; set; } 
    }

    public enum ChatRoomRole
    {
        Member = 1,
        Admin = 2,
        Owner = 3
    }
}
