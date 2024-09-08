using AMSS.Models;
using System.Security.Claims;

namespace AMSS.Services.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user, IEnumerable<string> roles);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
        bool ValidateTokenExpire(string token);
    }
}
