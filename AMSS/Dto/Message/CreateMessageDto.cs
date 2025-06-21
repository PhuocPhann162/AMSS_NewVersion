using AMSS.Entities.Messages;

namespace AMSS.Dto.Message
{
    public class CreateMessageDto
    {
        public string Content { get; set; }
        public Guid ChatRoomId { get; set; }
        public MessageType Type { get; set; }
    }
}
