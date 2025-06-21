using AMSS.Data;
using AMSS.Entities.ChatRooms;
using Microsoft.EntityFrameworkCore;

namespace AMSS.Repositories.ChatHubRepository
{
    public class ChatRoomRepository : Repository<ChatRoom>, IChatRoomRepository
    {
        private readonly ApplicationDbContext _db;
        public ChatRoomRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<Guid>> GetChatRoomIdsByUserAsync(string userId)
        {
            return await _db.ChatRooms
                .Where(cru => cru.CreatedById == userId && cru.IsActive)
                .Select(cru => cru.Id)
                .ToListAsync();
        }

        public async Task<ChatRoom> GetPrivateChatRoomBetweenTwoUsersAsync(Guid userId1, Guid userId2)
        {
            return await _db.ChatRooms
                .Where(cr => cr.Type == ChatRoomType.Private)
                .Where(cr => cr.ChatRoomUsers.Count == 2)
                .Where(cr => cr.ChatRoomUsers.Any(cru => cru.UserId == userId1.ToString() &&
                            cr.ChatRoomUsers.Any(cru => cru.UserId == userId2.ToString())))
                .FirstOrDefaultAsync();
        }
    }
}
