using DataAccess;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Autors.Commands.CreateAutorCommand
{
    public class CreateAutorHandler : IRequestHandler<CreateAutorRequest, int>
    {
        private ApplicationDBContext dbcontext;
        public CreateAutorHandler(ApplicationDBContext DbContext)
        {
            dbcontext = DbContext;
        }

        public async Task<int> Handle(CreateAutorRequest request, CancellationToken cancellationToken)
        {
            var autor = new Autor(request.Name, request.Surname);
            await dbcontext.Autors.AddAsync(autor);
            await dbcontext.SaveChangesAsync();
            return autor.ID;
        }
    }
}
