using System.ComponentModel.DataAnnotations;

namespace AMSS.Dto.Requests.Chats
{
    public class CreateGroupRoomRequest
    {
        [Required]
        [StringLength(150, ErrorMessage = "ContactName cannot be longer than 150 characters.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "ContactName cannot be longer than 500 characters.")]
        public string Description { get; set; }

        [Required]
        public List<Guid> MemberIds { get; set; }
    }
}
