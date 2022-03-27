using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
