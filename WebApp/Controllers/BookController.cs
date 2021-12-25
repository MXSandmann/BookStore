using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UseCases.Books.Commands.CreateBookCommand;

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
        public async Task<int> CreateBook()
        {
            var result = await mediator.Send(new CreateBookRequest());
            return result;
        }
    }
}
