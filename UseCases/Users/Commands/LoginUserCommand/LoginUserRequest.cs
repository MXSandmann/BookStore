using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Users.DTO;

namespace UseCases.Users.Commands.LoginUserCommand
{
    public record LoginUserRequest( string UserName, string Password) : IRequest<LoginResultDTO>;
    
}
