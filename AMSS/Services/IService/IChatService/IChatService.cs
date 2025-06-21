using AMSS.Dto.Message;
using AMSS.Dto.Requests.Chats;
using AMSS.Dto.Responses;
using AMSS.Dto.User;
using AMSS.Entities;

namespace AMSS.Services.IService.IChatService
{
    public interface IChatService
    {
        Task<APIResponse<IEnumerable<ChatRoomDto>>> GetUserChatRoomsAsync(Guid userId);
        Task<APIResponse<PaginationResponse<MessageDto>>> GetRoomMessagesAsync(Guid userId, Guid roomId, GetRoomMessagesRequest request);
        Task<APIResponse<ChatRoomDto>> CreateGroupRoomAsync(Guid creatorId, CreateGroupRoomRequest request);
        Task<APIResponse<bool>> AddUserToRoomAsync(Guid roomId, Guid userId, Guid addedById);
        Task<APIResponse<bool>> RemoveUserFromRoomAsync(Guid roomId, Guid userId, Guid removedById);
        Task<APIResponse<PaginationResponse<UserDto>>> SearchUsersAsync(Guid currentUserId, SearchUsersRequest request);
    }
}
