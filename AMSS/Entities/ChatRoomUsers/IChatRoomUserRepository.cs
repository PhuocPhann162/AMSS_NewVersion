using AMSS.Dto.Message;
using AMSS.Repositories.IRepository;

namespace AMSS.Entities.ChatRoomUsers
{
    public interface IChatRoomUserRepository : IRepository<ChatRoomUser>
    {
        Task<List<ChatRoomUser>> GetChatRoomsByUserId(Guid userId);

        Task<IEnumerable<ChatRoomDto>> GetUserChatRoomDtosByUserId(Guid userId);
    }
}
