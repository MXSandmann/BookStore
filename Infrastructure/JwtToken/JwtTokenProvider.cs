using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Infrastructure.JwtToken
{
    public class JwtTokenProvider : IJwtTokenProvider
    {
        private JwtOptions JwtOptions;
        public JwtTokenProvider(JwtOptions jwtOptions)
        {
            JwtOptions = jwtOptions;
        }
        public string CreateToken(IEnumerable<Claim> claims)
        {
            var handler = new JwtSecurityTokenHandler();
            var signingCredentials = new SigningCredentials(JwtOptions.GetKey(), SecurityAlgorithms.HmacSha256Signature);
            var identity = new ClaimsIdentity(claims);
            var token = handler.CreateJwtSecurityToken(subject: identity,
                signingCredentials: signingCredentials,
                issuer: JwtOptions.Issuer,
                audience: JwtOptions.Audience);
            return handler.WriteToken(token);
        }
    }
}
