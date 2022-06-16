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
        private readonly ApplicationDBContext _dbContext;

        public DeleteAutorHandler(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(DeleteAutorRequest request, CancellationToken cancellationToken)
        {
            var autor = await _dbContext.Autors.Include(a => a.Books).FirstOrDefaultAsync(a => a.ID == request.Id);
            _dbContext.Autors.Remove(autor);
            await _dbContext.SaveChangesAsync();
            return request.Id;
        }
    }
}
