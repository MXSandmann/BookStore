using DataAccess;
using Domain;
using Domain.Exceptions;
using Infrastructure.JwtToken;
using MediatR;
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
        private ApplicationDBContext dbContext;
        private IJwtTokenProvider jwtTokenProvider;
        public CreateUserHandler(ApplicationDBContext DbContext, IJwtTokenProvider JwtTokenProvider)
        {
            dbContext = DbContext;
            jwtTokenProvider = JwtTokenProvider;
        }
        public async Task<string> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            // Check if the new autor already exists in dbContext
            var existingUser = dbContext.Users.FirstOrDefault(s => s.UserName == request.UserName);

            if (existingUser != null)
            {
                throw new AlreadyExistException(typeof(User), existingUser.ID);
            }

            var user = new User(request.UserName, request.Password, request.Email, (Role)request.Role);
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            var list = new List<Claim>()
            {
                new Claim("Id", user.ID.ToString()),
                new Claim("UserName", user.UserName),
                new Claim("Role", user.Role.ToString())
            };
            return jwtTokenProvider.CreateToken(list);
        }
    }
}
