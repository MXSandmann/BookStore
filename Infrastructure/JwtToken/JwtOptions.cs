using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.JwtToken
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public SymmetricSecurityKey GetKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        public string Audience  { get; set; }
        public string Issuer { get; set; }  
    }
}
