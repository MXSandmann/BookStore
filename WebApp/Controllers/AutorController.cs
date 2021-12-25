using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UseCases.Autors.Commands.CreateAutorCommand;
using WebApp.DTO.Requests;

namespace WebApp.Controllers
{
    [Route("api/autor")]
    public class AutorController : ControllerBase
    {
        private IMediator mediator;
        public AutorController(IMediator Mediator)
        {
            mediator = Mediator;
        }

        [HttpPost("create")]
        public async Task<int> CreateAutor([FromBody] CreateAutorDTO dto)
        {
            var result = await mediator.Send(new CreateAutorRequest(dto.Name, dto.Surname));
            return result;
        }
    }
}
