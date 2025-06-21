using AMSS.Dto.User;

namespace AMSS.Dto.Message
{
    public class ChatRoomDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public List<UserDto> Members { get; set; } = new();
        public MessageDto? LastMessage { get; set; }
    }
}
