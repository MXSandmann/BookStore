using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UseCases.Books.Commands.CreateBookCommand;
using WebApp.DTO.Requests;

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
        public async Task<int> CreateBook([FromBody] CreateBookDTO dto)
        {
            var result = await mediator.Send(new CreateBookRequest(dto.Title,
                dto.Description,
                dto.PagesCount,
                dto.Year,
                dto.Price,
                dto.Autors,
                dto.Genres));
            return result;
        }
    }
}
