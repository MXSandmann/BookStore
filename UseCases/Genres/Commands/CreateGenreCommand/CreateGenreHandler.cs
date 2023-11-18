using DataAccess;
using Domain;
using Domain.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Genres.Commands.CreateGenreCommand
{
    public class CreateGenreHandler : IRequestHandler<CreateGenreRequest, int>
    {
        private readonly ApplicationDBContext _dbcontext;
        public CreateGenreHandler(ApplicationDBContext DbContext)
        {
            _dbcontext = DbContext;
        }




        public async Task<int> Handle(CreateGenreRequest request, CancellationToken cancellationToken)
        {
            // Check if the new genre already exists in dbContext
            var existingGenre = _dbcontext.Genres.FirstOrDefault(s => s.Name == request.Name);

            if (existingGenre != null)
                throw new AlreadyExistException(typeof(Genre), existingGenre.ID);


            var genre = new Genre(request.Name);
            await _dbcontext.Genres.AddAsync(genre);
            await _dbcontext.SaveChangesAsync();
            return genre.ID;
        }
    }
}
