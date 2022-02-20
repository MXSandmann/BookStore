using DataAccess;
using Domain;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Autors.Commands.UpdateAutorCommand
{
    public class UpdateAutorHandler : IRequestHandler<UpdateAutorRequest, int>
    {
        private ApplicationDBContext dbContext;
        public UpdateAutorHandler(ApplicationDBContext DbContext)
        {
            dbContext = DbContext;
        }
        public async Task<int> Handle(UpdateAutorRequest request, CancellationToken cancellationToken)
        {
            var autor = await dbContext.Autors.Include(a => a.Books).FirstOrDefaultAsync(a => a.ID == request.Id);
            if (autor == null)
                throw new NotFoundException(typeof(Autor), request.Id);

            return 0;
        }
    }
}
