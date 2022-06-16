using DataAccess;
using Domain;
using Domain.Enums;
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

namespace UseCases.Users.Commands.CreateUserCommand
{
    internal class CreateUserHandler : IRequestHandler<CreateUserRequest, string>
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IJwtTokenProvider _jwtTokenProvider;
        public CreateUserHandler(ApplicationDBContext DbContext, IJwtTokenProvider JwtTokenProvider)
        {
            _dbContext = DbContext;
            _jwtTokenProvider = JwtTokenProvider;
        }
        public async Task<string> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            // Check if the new autor already exists in dbContext
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(s => s.UserName == request.UserName);

            if (existingUser != null)
            {
                throw new AlreadyExistException(typeof(User), existingUser.ID);
            }

            var user = new User(request.UserName, request.Password, request.Email, (Role)request.Role);
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            var list = new List<Claim>()
            {
                new Claim("Id", user.ID.ToString()),
                new Claim("UserName", user.UserName),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
            return _jwtTokenProvider.CreateToken(list);
        }
    }
}
