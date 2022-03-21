using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UseCases.Users.Commands.CreateUserCommand;
using WebApp.DTO.Requests;

namespace WebApp.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private IMediator mediator;
        public UserController(IMediator Mediator)
        {
            mediator = Mediator;
        }
        [HttpPost]
        public async Task<string> CreateUser([FromBody] CreateUserDTO dto)
        {
            var result = await mediator.Send(new CreateUserRequest(dto.UserName, dto.Password, dto.Email, dto.Role));
            return result;
        }
    }
}
