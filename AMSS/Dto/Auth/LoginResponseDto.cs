using AMSS.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace AMSS.Dto.Auth
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public TokenDto Token { get; set; }
    }
}
