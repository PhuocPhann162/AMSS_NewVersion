using AMSS.Dto.Message;
using AMSS.Dto.Requests.Chats;
using AMSS.Dto.Responses;
using AMSS.Dto.User;
using AMSS.Entities;
using AMSS.Models;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService.IChatService;
using System.Linq.Expressions;
using AMSS.Entities.Messages;
using AMSS.Entities.ChatRooms;
using AMSS.Entities.ChatRoomUsers;

namespace AMSS.Services.ChatService
{
    public class ChatService : BaseService, IChatService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChatService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<APIResponse<IEnumerable<ChatRoomDto>>> GetUserChatRoomsAsync(Guid userId)
        {
            var chatRooms = await _unitOfWork.ChatRoomUserRepository.GetUserChatRoomDtosByUserId(userId);

            return BuildSuccessResponseMessage(chatRooms);
        }

        public async Task<APIResponse<PaginationResponse<MessageDto>>> GetRoomMessagesAsync(Guid userId, Guid roomId, GetRoomMessagesRequest request)
        {
            var sortExpressions = new List<SortExpression<Message>>();

            var sortFieldMap = new Dictionary<string, Expression<Func<Message, object>>>(StringComparer.OrdinalIgnoreCase)
            {
                ["CreatedAt"] = x => x.CreatedAt,
            };

            if (!string.IsNullOrEmpty(request.OrderBy) && sortFieldMap.TryGetValue(request.OrderBy, out var sortField))
            {
                sortExpressions.Add(new SortExpression<Message>(sortField, request.OrderByDirection));
            }

            Expression<Func<Message, bool>> filter = x =>
                    x.ChatRoomId == roomId && !x.IsEdited &&
                   (string.IsNullOrEmpty(request.Search) || x.Content.Contains(request.Search));

            var messagesPaginationResult = await _unitOfWork.MessageRepository.GetPaginationIncludeAsync(
                filter,
                request.CurrentPage, request.Limit,
                sortExpressions.ToArray(),
                includes: [x => x.Sender]);
            var response = new PaginationResponse<MessageDto>(messagesPaginationResult.CurrentPage, messagesPaginationResult.Limit,
                            messagesPaginationResult.TotalRow, messagesPaginationResult.TotalPage)
            {
                Collection = messagesPaginationResult.Data.Select(x => new MessageDto
                {
                    Id = x.Id,
                    Content = x.Content,
                    Type = x.Type.ToString(),
                    SenderId = x.SenderId,
                    SenderName = x.Sender.FullName,
                    ChatRoomId = x.ChatRoomId,
                    SentAt = x.SentAt,
                    IsEdited = x.IsEdited
                })
            };

            return BuildSuccessResponseMessage(response);
        }

        public async Task<APIResponse<bool>> AddUserToRoomAsync(Guid roomId, Guid userId, Guid addedById)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<ChatRoomDto>> CreateGroupRoomAsync(Guid creatorId, CreateGroupRoomRequest request)
        {
            var room = new ChatRoom
            {
                Name = request.Name,
                Description = request.Description,
                Type = ChatRoomType.Group,
                CreatedById = creatorId.ToString(),
                CreatedAt = DateTime.Now
            };

            await _unitOfWork.ChatRoomRepository.AddAsync(room);

            // Add creator as owner
            var roomUsers = new List<ChatRoomUser>
            {
                new() { UserId = creatorId.ToString(), ChatRoomId = room.Id, Role = ChatRoomRole.Owner, CreatedAt = DateTime.Now }
            };

            // Add other members
            foreach (var memberId in request.MemberIds.Where(id => id != creatorId))
            {
                roomUsers.Add(new ChatRoomUser { UserId = memberId.ToString(), ChatRoomId = room.Id, Role = ChatRoomRole.Member, CreatedAt = DateTime.Now });
            }

            await _unitOfWork.ChatRoomUserRepository.AddRangeAsync(roomUsers);
            await _unitOfWork.SaveChangeAsync();

            // Return created room DTO
            var roomDto = await GetRoomDto(room.Id);
            return BuildSuccessResponseMessage(roomDto);
        }

        public async Task<APIResponse<bool>> RemoveUserFromRoomAsync(Guid roomId, Guid userId, Guid removedById)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<PaginationResponse<UserDto>>> SearchUsersAsync(Guid currentUserId, SearchUsersRequest request)
        {
            var sortExpressions = new List<SortExpression<ApplicationUser>>();

            var sortFieldMap = new Dictionary<string, Expression<Func<ApplicationUser, object>>>(StringComparer.OrdinalIgnoreCase)
            {
                ["IsOnline"] = x => x.IsOnline
            };

            if (!string.IsNullOrEmpty(request.OrderBy) && sortFieldMap.TryGetValue(request.OrderBy, out var sortField))
            {
                sortExpressions.Add(new SortExpression<ApplicationUser>(sortField, request.OrderByDirection));
            }

            Expression<Func<ApplicationUser, bool>> filter = x =>
                   (string.IsNullOrEmpty(request.Search) || x.FullName.Contains(request.Search));

            var usersPaginationResult = await _unitOfWork.UserRepository.GetAsync(
                filter,
                request.CurrentPage, request.Limit,
                sortExpressions.ToArray());
            var response = new PaginationResponse<UserDto>(usersPaginationResult.CurrentPage, usersPaginationResult.Limit,
                            usersPaginationResult.TotalRow, usersPaginationResult.TotalPage)
            {
                Collection = usersPaginationResult.Data.Select(u => new UserDto
                {
                    Id = Guid.Parse(u.Id),
                    FullName = u.FullName,
                    IsOnline = u.IsOnline,
                    Avatar = u.Avatar,
                    LastSeen = u.LastSeen
                })
            };

            return BuildSuccessResponseMessage(response);
        }

        private async Task<ChatRoomDto?> GetRoomDto(Guid roomId)
        {
            var room = await _unitOfWork.ChatRoomRepository
                .FirstOrDefaultAsync(cr => cr.Id == roomId);
            if(room is null)
            {
                return null;
            }
            var roomDto = new ChatRoomDto
            {
                Id = room.Id,
                Name = room.Name,
                Description = room.Description,
                Type = room.Type.ToString(),
                CreatedAt = room.CreatedAt,
            };

            return roomDto;
        }
    }
}
