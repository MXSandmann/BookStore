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
using UseCases.Autors.Commands.UpdateAutorCommand;
using UseCases.Autors.Commands.DeleteAutorCommand;
using UseCases.Common;

namespace WebApp.Controllers
{
    [Route("api/autor")]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<APIResponse<int>> CreateAutor([FromBody] CreateAutorDTO dto)
        {
            var result = await _mediator.Send(new CreateAutorRequest(dto.Name, dto.Surname));
            return APIResponse<int>.OK(result);
        }

        [HttpGet("get/{id}")]
        public async Task<APIResponse<AutorWithBooksDTO>> GetAutorById(int id)
        {
            var result = await _mediator.Send(new GetAutorByIdRequest(id));
            return APIResponse<AutorWithBooksDTO>.OK(result);

        }


        [HttpGet("get")]
        public async Task<APIResponse<PaginationResponse<AutorWithBooksDTO>>> GetAutorAll([FromQuery] GetAutorsRequest dto)
        {
            var result = await _mediator.Send(new GetAutorAllRequest(dto.Offset, dto.Limit, dto.Name, dto.Surname));
            return APIResponse<PaginationResponse<AutorWithBooksDTO>>.OK(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<APIResponse<int>> DeleteAutor(int id)
        {
            var result = await _mediator.Send(new DeleteAutorRequest(id));
            return APIResponse<int>.OK(result);
        }

        
        [HttpPut("update")]
        public async Task<APIResponse<int>> UpdateAutor([FromBody] UpdateAutorDTO dto)
        {
            var result = await _mediator.Send(new UpdateAutorRequest(dto.Id, dto.Name, dto.Surname));
            return APIResponse<int>.OK(result);
        }



    }
}
