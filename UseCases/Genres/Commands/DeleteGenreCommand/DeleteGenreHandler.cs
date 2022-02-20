using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Genres.Commands.DeleteGenreCommand
{
    public class DeleteGenreHandler : IRequestHandler<DeleteGenreRequest, int>
    {
        private ApplicationDBContext dbContext;

        public DeleteGenreHandler(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Handle(DeleteGenreRequest request, CancellationToken cancellationToken)
        {
            var genre = await dbContext.Genres.Include(b => b.Books).FirstOrDefaultAsync(b => b.ID == request.Id);

            dbContext.Genres.Remove(genre);

            await dbContext.SaveChangesAsync();
            return request.Id;
        }
    }
}
