using DataAccess;
using Domain;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Books.Commands.UpdateBookRequest
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookRequest, int>
    {
        private readonly ApplicationDBContext _dbContext;
        public UpdateBookHandler(ApplicationDBContext DbContext)
        {
            _dbContext = DbContext;
        }
        public async Task<int> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.ID == request.ID);
            if (book is null)
                throw new NotFoundException(typeof(Book), request.ID);
            book.Update(request.Title, request.PagesCount, request.Year, request.Price);
            await _dbContext.SaveChangesAsync();
            return book.ID;
        }
    }
}
