using AMSS.Dto.Message;
using AMSS.Entities.ChatRooms;
using AMSS.Entities.ChatRoomUsers;
using AMSS.Entities.Messages;
using AMSS.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace AMSS.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ChatHub> _logger;
        private static readonly Dictionary<string, string> _userConnections = new();

        public ChatHub(IUnitOfWork unitOfWork, ILogger<ChatHub> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public override async Task OnConnectedAsync()
        {
            _logger.LogInformation("BEGIN: OnConnectedAsync - ConnectionId: {ConnectionId}", Context.ConnectionId);
            var userId = Context.UserIdentifier;
            if (userId != null)
            {
                _userConnections[userId] = Context.ConnectionId;

                // Update user online status
                var user = await _unitOfWork.UserRepository.FirstOrDefaultAsync(x => x.Id.Equals(userId));
                if (user != null)
                {
                    user.IsOnline = true;
                    await _unitOfWork.SaveChangeAsync();
                }

                // Join user to their chat rooms
                var userRooms = await _unitOfWork.ChatRoomRepository.GetChatRoomIdsByUserAsync(userId);

                foreach (var roomId in userRooms)
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, $"Room_{roomId}");
                }

                // Notify others that user is online
                await Clients.Others.SendAsync("UserOnline", userId);
            }

            await base.OnConnectedAsync();
            _logger.LogInformation("END: OnConnectedAsync");

            // Gửi cho user vừa connect danh sách user đang online
            await Clients.Caller.SendAsync("OnlineUsers", _userConnections.Keys.ToList());
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            _logger.LogInformation("BEGIN: OnDisconnectedAsync - ConnectionId: {ConnectionId}", Context.ConnectionId);

            var userId = Context.UserIdentifier;
            if (userId != null)
            {
                _userConnections.Remove(userId);

                // Update user offline status
                var user = await _unitOfWork.UserRepository.FirstOrDefaultAsync(x => x.Id.Equals(userId));

                if (user != null)
                {
                    user.IsOnline = false;
                    user.LastSeen = DateTime.UtcNow;
                    await _unitOfWork.SaveChangeAsync();
                }

                // Notify others that user is offline
                await Clients.Others.SendAsync("UserOffline", userId);
            }

            await base.OnDisconnectedAsync(exception);

            _logger.LogInformation("END: OnDisconnectedAsync");
        }

        public async Task JoinRoom(Guid roomId)
        {
            var userId = Context.UserIdentifier;
            _logger.LogInformation("BEGIN: JoinChatRoom - UserId: {UserId}, RoomId: {RoomId}",
            userId, roomId);

            try
            {
                // Check if user is member of the room
                var membership = await _unitOfWork.ChatRoomUserRepository
                    .FirstOrDefaultAsync(cru => cru.UserId == userId && cru.ChatRoomId == roomId && cru.IsActive);

                if (membership != null)
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, $"Room_{roomId}");
                    await Clients.Group($"Room_{roomId}").SendAsync("UserJoinedRoom", userId, roomId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error during JoinChatRoom");
                throw;
            }
            _logger.LogInformation("JoinChatRoom: User {UserId} joined conversation {RoomId}", userId, roomId);
        }

        public async Task LeaveRoom(Guid roomId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"Room_{roomId}");
            await Clients.Group($"Room_{roomId}").SendAsync("UserLeftRoom", Context.UserIdentifier, roomId);
        }

        public async Task SendMessageToRoom(CreateMessageDto messageDto)
        {
            var userId = Context.UserIdentifier;

            _logger.LogInformation("BEGIN: SendMessage - ConversationId: {ConversationId}, SenderId: {SenderId}",
            Context.ConnectionId, userId);

            try
            {
                // Verify user is member of the room
                var membership = await _unitOfWork.ChatRoomUserRepository
                    .FirstOrDefaultAsync(cru => cru.UserId == userId && cru.ChatRoomId == messageDto.ChatRoomId && cru.IsActive);

                if (membership == null)
                {
                    await Clients.Caller.SendAsync("Error", "You are not a member of this room");
                    return;
                }

                // Create and save message
                var message = new Message
                {
                    Content = messageDto.Content,
                    Type = messageDto.Type,
                    SenderId = userId,
                    ChatRoomId = messageDto.ChatRoomId,
                    SentAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                };

                await _unitOfWork.MessageRepository.AddAsync(message);
                await _unitOfWork.SaveChangeAsync();

                // Load sender info
                var sender = await _unitOfWork.UserRepository.FirstOrDefaultAsync(x => x.Id.Equals(userId));


                var responseDto = new MessageDto
                {
                    Id = message.Id,
                    Content = message.Content,
                    Type = message.Type.ToString(),
                    SenderId = message.SenderId,
                    SenderName = sender?.FullName ?? "Unknown",
                    ChatRoomId = message.ChatRoomId,
                    SentAt = message.SentAt,
                    IsEdited = message.IsEdited
                };

                // Send to all room members
                await Clients.Group($"Room_{messageDto.ChatRoomId}").SendAsync("ReceiveMessage", responseDto);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Unexpected error during SendMessage");
                throw;
            }
            _logger.LogInformation("END: SendMessage");
        }

        public async Task SendTyping(Guid roomId, bool isTyping)
        {
            var userId = Context.UserIdentifier;
            await Clients.Group($"Room_{roomId}").SendAsync("UserTyping", userId, isTyping);
        }

        public async Task SendPrivateMessage(Guid recipientId, string content)
        {
            var senderId = Guid.Parse(Context.UserIdentifier!);
            _logger.LogInformation("BEGIN: SendMessage - ConversationId: {ConversationId}, SenderId: {SenderId}",
            Context.ConnectionId, senderId);


            // Find or create private room between users
            var privateRoom = await GetOrCreatePrivateRoom(senderId, recipientId);

            var messageDto = new CreateMessageDto
            {
                Content = content,
                ChatRoomId = privateRoom.Id,
                Type = MessageType.Text,
            };

            await SendMessageToRoom(messageDto);
        }

        private async Task<ChatRoom> GetOrCreatePrivateRoom(Guid user1Id, Guid user2Id)
        {
            // Look for existing private room between these users
            var existingRoom = await _unitOfWork.ChatRoomRepository.GetPrivateChatRoomBetweenTwoUsersAsync(user1Id, user2Id);

            if (existingRoom != null)
                return existingRoom;

            // Create new private room
            var userMessageTo = await _unitOfWork.UserRepository.GetByIdAsync(user2Id.ToString()); 
            var room = new ChatRoom
            {
                Name = userMessageTo.FullName,
                Type = ChatRoomType.Private,
                CreatedById = user1Id.ToString(),
                CreatedAt = DateTime.Now
            };

            await _unitOfWork.ChatRoomRepository.AddAsync(room);

            // Add both users to the room
            var roomUsers = new List<ChatRoomUser>
            {
                new() { UserId = user1Id.ToString(), ChatRoomId = room.Id, Role = ChatRoomRole.Member, CreatedAt = DateTime.Now },
                new() { UserId = user2Id.ToString(), ChatRoomId = room.Id, Role = ChatRoomRole.Member, CreatedAt = DateTime.Now }
            };

            await _unitOfWork.ChatRoomUserRepository.AddRangeAsync(roomUsers);
            await _unitOfWork.SaveChangeAsync();

            return room;
        }
    }
}
