using MediatR;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Genres.Commands.CreateGenreCommand
{
    public class CreateGenreHandler : IRequestHandler<CreateGenreRequest, int>
    {
        private ApplicationDBContext dbcontext;
        public CreateGenreHandler(ApplicationDBContext DbContext)
        {
            dbcontext = DbContext;
        }
        public async Task<int> Handle(CreateGenreRequest request, CancellationToken cancellationToken)
        {
            var genre = new Genre(request.Name);
            await dbcontext.Genres.AddAsync(genre);
            await dbcontext.SaveChangesAsync();
            return genre.ID;
        }
    }
}
