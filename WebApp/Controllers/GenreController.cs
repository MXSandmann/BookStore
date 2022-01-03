using MediatR;
using UseCases.Genres.Commands.CreateGenreCommand;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.DTO.Requests;

namespace WebApp.Controllers
{
    [Route("api/genre")]
    public class GenreController : ControllerBase
    {
        private IMediator mediator;
        public GenreController(IMediator Mediator)
        {
            mediator = Mediator;    
        }

        [HttpPost("create")]
        public async Task<int> CreateGenre([FromBody] CreateGenreDTO dto)
        {
            var result = await mediator.Send(new CreateGenreRequest(dto.Name));
            return result;
        }
    }
}
