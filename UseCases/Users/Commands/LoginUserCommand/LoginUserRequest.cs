using MediatR;
using UseCases.Users.DTO;

namespace UseCases.Users.Commands.LoginUserCommand
{
    public record LoginUserRequest(string UserName, string Password) : IRequest<LoginResultDTO>;

}
