using System.Collections.Generic;
using System.Security.Claims;

namespace Infrastructure.JwtToken
{
    public interface IJwtTokenProvider
    {
        string CreateToken(IEnumerable<Claim> claims);
    }
}
