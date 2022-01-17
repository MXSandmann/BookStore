using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UseCases.Autors.Commands.CreateAutorCommand;
using WebApp.DTO.Requests;
using WebApp.DTO.Responses;
using UseCases.DTO.Responses;
using UseCases.Autors.Queries.GetAutorQuery.All;
using UseCases.Autors.Queries.GetAutorQuery.ByID;
using System.Collections.Generic;


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
        public async Task<APIResponse<int>> CreateAutor([FromBody] CreateAutorDTO dto)
        {
            var result = await mediator.Send(new CreateAutorRequest(dto.Name, dto.Surname));
            return APIResponse<int>.OK(result);
        }

        [HttpGet("get/{id}")]
        public async Task<APIResponse<AutorWithBooksDTO>> GetAutorById(int id)
        {
            var result = await mediator.Send(new GetAutorByIdRequest(id));
            //return result;
            return APIResponse<AutorWithBooksDTO>.OK(result);

        }

        [HttpGet("get")]
        public async Task<APIResponse<IEnumerable<AutorWithBooksDTO>>> GetAutorAll()
        {
            var result = await mediator.Send(new GetAutorAllRequest());
            return APIResponse<IEnumerable<AutorWithBooksDTO>>.OK(result);
        }


    }
}
