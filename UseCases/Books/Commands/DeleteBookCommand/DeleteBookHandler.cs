using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Books.Commands.DeleteBookCommand
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookRequest, int>
    {
        private readonly ApplicationDBContext _dbContext;

        public DeleteBookHandler(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.Include(b => b.Autors).Include(b => b.Genres).FirstOrDefaultAsync(b => b.ID == request.Id);

            _dbContext.Books.Remove(book);

            await _dbContext.SaveChangesAsync();
            return request.Id;
        }
    }
}
