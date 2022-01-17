using DataAccess;
using Domain;
using Domain.Exceptions;
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
        private ApplicationDBContext dbContext;
        public CreateAutorHandler(ApplicationDBContext DbContext)
        {
            dbContext = DbContext;
        }

        public async Task<int> Handle(CreateAutorRequest request, CancellationToken cancellationToken)
        {
            // Check if the new autor already exists in dbContext
            var existingAutor = dbContext.Autors.FirstOrDefault(s => s.Name == request.Name && s.Surname == request.Surname);

            if (existingAutor != null)
            {
                throw new AlreadyExistException(typeof(Autor), existingAutor.ID);
            }

            var autor = new Autor(request.Name, request.Surname);
            await dbContext.Autors.AddAsync(autor);
            await dbContext.SaveChangesAsync();
            return autor.ID;
        }
    }
}
