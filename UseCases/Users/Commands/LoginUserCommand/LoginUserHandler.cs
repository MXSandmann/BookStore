using DataAccess;
using Domain;
using Domain.Exceptions;
using Infrastructure.JwtToken;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Users.DTO;

namespace UseCases.Users.Commands.LoginUserCommand
{
    internal class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginResultDTO>
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IJwtTokenProvider _jwtTokenProvider;
        public LoginUserHandler(ApplicationDBContext DbContext, IJwtTokenProvider JwtTokenProvider)
        {
            _dbContext = DbContext;
            _jwtTokenProvider = JwtTokenProvider;
        }
        public async Task<LoginResultDTO> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            // Check if the new autor already exists in dbContext
            var user = await _dbContext.Users.FirstOrDefaultAsync(s => s.UserName == request.UserName && s.Password == request.Password);

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
                Token = _jwtTokenProvider.CreateToken(list),
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
