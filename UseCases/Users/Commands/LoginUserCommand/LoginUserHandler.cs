using DataAccess;
using Domain;
using Domain.Exceptions;
using Infrastructure.JwtToken;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Users.DTO;

namespace UseCases.Users.Commands.LoginUserCommand
{
    internal class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginResultDTO>
    {
        private ApplicationDBContext dbContext;
        private IJwtTokenProvider jwtTokenProvider;
        public LoginUserHandler(ApplicationDBContext DbContext, IJwtTokenProvider JwtTokenProvider)
        {
            dbContext = DbContext;
            jwtTokenProvider = JwtTokenProvider;
        }
        public async Task<LoginResultDTO> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            // Check if the new autor already exists in dbContext
            var user = await dbContext.Users.FirstOrDefaultAsync(s => s.UserName == request.UserName && s.Password == request.Password);

            if (user == null)
            {
                throw new NotFoundException(typeof(User), user.ID);
            }

            var list = new List<Claim>()
            {
                new Claim("Id", user.ID.ToString()),
                new Claim("UserName", user.UserName),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            return new LoginResultDTO
            {
                Token = jwtTokenProvider.CreateToken(list),
                User = new UserDTO()
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    Email = user.Email,
                    Role = user.Role.ToString()
                }
            };
        }
    }
}
