using DataAccess;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Books.Commands.CreateBookCommand
{
    public class CreateBookHandler : IRequestHandler<CreateBookRequest, int>
    {
        private ApplicationDBContext dbcontext;
        public CreateBookHandler(ApplicationDBContext DbContext)
        {
            dbcontext = DbContext;
        }

        public async Task<int> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            var book = new Book(request.Title,
                request.Description,
                request.PagesCount,
                request.Year,
                request.Price,
                request.Autors,
                request.Genres);
            await dbcontext.Books.AddAsync(book);
            await dbcontext.SaveChangesAsync();
            return book.ID;
        }
    }
}
