using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Autors.Commands.DeleteAutorCommand
{
    public class DeleteAutorHandler : IRequestHandler<DeleteAutorRequest, int>
    {
        private ApplicationDBContext dbContext;

        public DeleteAutorHandler(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Handle(DeleteAutorRequest request, CancellationToken cancellationToken)
        {
            var autor = await dbContext.Autors.Include(a => a.Books).FirstOrDefaultAsync(a => a.ID == request.Id);
            dbContext.Autors.Remove(autor);
            await dbContext.SaveChangesAsync();
            return request.Id;
        }
    }
}
