using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace UseCases.Books.Commands.DeleteBookCommand
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookRequest, int>
    {
        private ApplicationDBContext dbContext;

        public DeleteBookHandler(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
        {
            var book = await dbContext.Books.Include(b => b.Autors).Include(b => b.Genres).FirstOrDefaultAsync(b => b.ID == request.Id);

            dbContext.Books.Remove(book);
            
            await dbContext.SaveChangesAsync();
            return request.Id;
        }
    }
}
