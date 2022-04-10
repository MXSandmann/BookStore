using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Domain.Exceptions;
using Domain;

namespace UseCases.Books.Commands.UpdateBookRequest
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookRequest, int>
    {
        private ApplicationDBContext dbContext;
        public UpdateBookHandler(ApplicationDBContext DbContext)
        {
            dbContext = DbContext;
        }
        public async Task<int> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            var book = await dbContext.Books.FirstOrDefaultAsync(b => b.Title == request.Title);
            if (book is null)
                throw new NotFoundException(typeof(Book), request.ID);
            book.Update(request.Title, request.PagesCount, request.Year, request.Price);
            await dbContext.SaveChangesAsync();
            return book.ID;
        }
    }
}
