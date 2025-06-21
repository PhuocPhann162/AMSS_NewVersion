using AMSS.Dto.Message;
using AMSS.Dto.Requests.Chats;
using AMSS.Dto.Responses;
using AMSS.Entities;
using AMSS.Entities.ChatRooms;
using AMSS.Services.IService.IChatService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace AMSS.Controllers
{
    [Route("api/chats")]
    [ApiController]
    [Authorize]
    public class ChatController : BaseController<ChatController>
    {
        private readonly IChatService _chatService;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet("get-rooms")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<ChatRoom>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserChatRoomsAsync()
        {
            var response = await _chatService.GetUserChatRoomsAsync(AuthenticatedUserId);
            return ProcessResponseMessage(response);
        }

        [HttpGet("{roomId:Guid}/get-room-messages")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<PaginationResponse<MessageDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRoomMessagesAsync(Guid roomId, [FromQuery] GetRoomMessagesRequest request)
        {
            var response = await _chatService.GetRoomMessagesAsync(AuthenticatedUserId, roomId, request);
            return ProcessResponseMessage(response);
        }

        [HttpPost("create-room")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<ChatRoomDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateChatRoomsAsync([FromBody] CreateGroupRoomRequest request)
        {
            var response = await _chatService.CreateGroupRoomAsync(AuthenticatedUserId, request);
            return ProcessResponseMessage(response);
        }

        [HttpGet("search-users")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<PaginationResponse<ChatRoom>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchUsersAsync([FromQuery] SearchUsersRequest request)
        {
            var response = await _chatService.SearchUsersAsync(AuthenticatedUserId, request);
            return ProcessResponseMessage(response);
        }
    }
}
