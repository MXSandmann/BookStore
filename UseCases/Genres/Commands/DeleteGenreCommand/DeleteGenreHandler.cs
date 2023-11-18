using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Genres.Commands.DeleteGenreCommand
{
    public class DeleteGenreHandler : IRequestHandler<DeleteGenreRequest, int>
    {
        private readonly ApplicationDBContext _dbContext;

        public DeleteGenreHandler(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(DeleteGenreRequest request, CancellationToken cancellationToken)
        {
            var genre = await _dbContext.Genres.Include(b => b.Books).FirstOrDefaultAsync(b => b.ID == request.Id);

            _dbContext.Genres.Remove(genre);

            await _dbContext.SaveChangesAsync();
            return request.Id;
        }
    }
}
