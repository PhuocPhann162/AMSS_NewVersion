using AMSS.Data;
using AMSS.Entities.ChatRoomUsers;
using Microsoft.EntityFrameworkCore;
using AMSS.Dto.Message;
using AMSS.Dto.User;
using AMSS.Dto.Responses;

namespace AMSS.Repositories.ChatHubRepository
{
    public class ChatRoomUserRepository : Repository<ChatRoomUser>, IChatRoomUserRepository
    {
        private readonly ApplicationDbContext _db;
        public ChatRoomUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<ChatRoomUser>> GetChatRoomsByUserId(Guid userId)
        {
            return await _db.ChatRoomUsers
                .Where(cru => cru.UserId == userId.ToString() && cru.IsActive)
                .Include(cru => cru.User)
                .Include(cru => cru.ChatRoom)
                    .ThenInclude(cr => cr.ChatRoomUsers)
                    .ThenInclude(cru => cru.User)
                .Include(cru => cru.ChatRoom)
                    .ThenInclude(cr => cr.Messages.OrderByDescending(m => m.SentAt).Take(1))
                    .ThenInclude(m => m.Sender).ToListAsync();
        }

        public async Task<IEnumerable<ChatRoomDto>> GetUserChatRoomDtosByUserId(Guid userId)
        {
            return await _db.ChatRoomUsers
                .Where(cru => cru.UserId == userId.ToString() && cru.IsActive)
                .Select(cru => new ChatRoomDto
                {
                    Id = cru.ChatRoom.Id,
                    Name = cru.ChatRoom.Name,
                    Description = cru.ChatRoom.Description,
                    Type = cru.ChatRoom.Type.ToString(),
                    CreatedAt = cru.ChatRoom.CreatedAt,
                    Members = cru.ChatRoom.ChatRoomUsers
                        .Where(cu => cu.IsActive && cu.User != null)
                        .Select(cu => new UserDto
                        {
                            Id = Guid.Parse(cu.User.Id),
                            FullName = cu.User.FullName,
                            IsOnline = cu.User.IsOnline,
                            LastSeen = cu.User.LastSeen
                        }).ToList(),
                    LastMessage = cru.ChatRoom.Messages
                        .OrderByDescending(m => m.SentAt)
                        .Select(m => new MessageDto
                        {
                            Id = m.Id,
                            Content = m.Content,
                            Type = m.Type.ToString(),
                            SenderId = m.SenderId,
                            SenderName = m.Sender.FullName ?? m.Sender.Email,
                            ChatRoomId = m.ChatRoomId,
                            SentAt = m.SentAt,
                            IsEdited = m.IsEdited
                        }).FirstOrDefault()
                })
                .ToListAsync();
        }
    }
}
