using AMSS.Repositories.IRepository;

namespace AMSS.Entities.ChatRooms
{
    public interface IChatRoomRepository : IRepository<ChatRoom>
    {
        Task<List<Guid>> GetChatRoomIdsByUserAsync(string userId);
        Task<ChatRoom> GetPrivateChatRoomBetweenTwoUsersAsync(Guid userId1, Guid userId2);
    }
}
