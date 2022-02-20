using MediatR;
using UseCases.Genres.Commands.CreateGenreCommand;
using UseCases.Genres.Queries.GetGenreQuery.All;
using UseCases.Genres.Queries.GetGenreQuery.ByID;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.DTO.Requests;
using WebApp.DTO.Responses;
using System.Collections.Generic;
using UseCases.DTO.Responses;
using UseCases.Genres.Commands.DeleteGenreCommand;

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
        public async Task<APIResponse<int>> CreateGenre([FromBody] CreateGenreDTO dto)
        {
            var result = await mediator.Send(new CreateGenreRequest(dto.Name));
            return APIResponse<int>.OK(result);
        }

        [HttpGet("get/{id}")]
        public async Task<APIResponse<GenreDTO>> GetGenreByID(int id) 
        {
            var result = await mediator.Send(new GetGenreByIDRequest(id));

            return APIResponse<GenreDTO>.OK(result);

        }

        [HttpGet("get")]
        public async Task<APIResponse<IEnumerable<GenreDTO>>> GetGenresAll()
        {
            var result = await mediator.Send(new GetGenreAllRequest());

            return APIResponse<IEnumerable<GenreDTO>>.OK(result); 

        }

        [HttpDelete("delete/{id}")]
        public async Task<APIResponse<int>> DeleteGenre(int id)
        {
            var result = await mediator.Send(new DeleteGenreRequest(id));
            return APIResponse<int>.OK(result);
        }
    }
}
