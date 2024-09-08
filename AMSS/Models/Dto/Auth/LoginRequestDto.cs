using System.ComponentModel.DataAnnotations;

namespace AMSS.Models.Dto.Auth
{
    public class LoginRequestDto
    {
        [EmailAddress]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
