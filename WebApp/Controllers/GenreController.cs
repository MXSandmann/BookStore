using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UseCases.DTO.Responses;
using UseCases.Genres.Commands.CreateGenreCommand;
using UseCases.Genres.Commands.DeleteGenreCommand;
using UseCases.Genres.Queries.GetGenreQuery.All;
using UseCases.Genres.Queries.GetGenreQuery.ByID;
using WebApp.DTO.Requests;
using WebApp.DTO.Responses;

namespace WebApp.Controllers
{
    [Route("api/genre")]
    public class GenreController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GenreController(IMediator Mediator)
        {
            _mediator = Mediator;
        }

        [HttpPost("create")]
        public async Task<APIResponse<int>> CreateGenre([FromBody] CreateGenreDTO dto)
        {
            var result = await _mediator.Send(new CreateGenreRequest(dto.Name));
            return APIResponse<int>.OK(result);
        }

        [HttpGet("get/{id}")]
        public async Task<APIResponse<GenreDTO>> GetGenreByID(int id)
        {
            var result = await _mediator.Send(new GetGenreByIDRequest(id));

            return APIResponse<GenreDTO>.OK(result);

        }

        [HttpGet("get")]
        public async Task<APIResponse<IEnumerable<GenreDTO>>> GetGenresAll()
        {
            var result = await _mediator.Send(new GetGenreAllRequest());

            return APIResponse<IEnumerable<GenreDTO>>.OK(result);

        }

        [HttpDelete("delete/{id}")]
        public async Task<APIResponse<int>> DeleteGenre(int id)
        {
            var result = await _mediator.Send(new DeleteGenreRequest(id));
            return APIResponse<int>.OK(result);
        }
    }
}
