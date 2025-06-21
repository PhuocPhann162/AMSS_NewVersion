using AMSS.Entities.Messages;

namespace AMSS.Dto.Message
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; } 
        public string Type { get; set; } 
        public string SenderId { get; set; }
        public string SenderName { get; set; } 
        public Guid ChatRoomId { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsEdited { get; set; }
    }
}
