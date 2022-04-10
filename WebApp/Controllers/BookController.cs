using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UseCases.Books.Commands.CreateBookCommand;
using UseCases.Books.Queries.GetBookAll;
using UseCases.Books.Queries.GetBookByID;
using UseCases.DTO.Responses;
using WebApp.DTO.Requests;
using WebApp.DTO.Responses;
using UseCases.Books.Commands.DeleteBookCommand;
using Microsoft.AspNetCore.Authorization;
using UseCases.Books.Commands.UpdateBookRequest;

namespace WebApp.Controllers
{
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private IMediator mediator;
        public BookController(IMediator Mediator) 
        {
            mediator = Mediator;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<APIResponse<int>> CreateBook([FromBody] CreateBookDTO dto)
        {
            var result = await mediator.Send(new CreateBookRequest(dto.Title,
                dto.Description,
                dto.PagesCount,
                dto.Year,
                dto.Price,
                dto.Autors,
                dto.Genres));
            return APIResponse<int>.OK(result);
        }

        [HttpGet("get")]
        public async Task<APIResponse<IEnumerable<BookDTO>>> GetAllBooks()
        {
            var result = await mediator.Send(new GetBookAllRequest());
            return APIResponse<IEnumerable<BookDTO>>.OK(result);
        }

        [HttpGet("get/{id}")]
        public async Task<APIResponse<BookDTO>> GetBookById(int id)
        {
            var result = await mediator.Send(new GetBookByIDRequest(id));
            return APIResponse<BookDTO>.OK(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<APIResponse<int>> DeleteBook(int id)
        {
            var result = await mediator.Send(new DeleteBookRequest(id));
            return APIResponse<int>.OK(result);
        }

        [HttpPut("update")]
        public async Task<APIResponse<int>> UpdateBook([FromBody] UpdateBookDTO dto)
        {
            var result = await mediator.Send(new UpdateBookRequest(dto.Id, dto.Title, dto.Price, dto.PagesCount, dto.Year));
            return APIResponse<int>.OK(result);
        }
    }
}
