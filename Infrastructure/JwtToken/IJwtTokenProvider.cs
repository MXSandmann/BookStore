﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.JwtToken
{
    public interface IJwtTokenProvider
    {
       string CreateToken(IEnumerable<Claim> claims);
    }
}
