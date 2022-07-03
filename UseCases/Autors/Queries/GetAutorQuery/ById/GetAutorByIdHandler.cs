using DataAccess;
using Domain;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UseCases.DTO.Responses;
using DataAccess.Contracts;

namespace UseCases.Autors.Queries.GetAutorQuery.ByID
{
    public class GetAutorByIdHandler : IRequestHandler<GetAutorByIdRequest, AutorWithBooksDTO>
    {        
        private readonly IAutorRepository _autorRepository;

        public GetAutorByIdHandler(IAutorRepository autorRepository)
        {            
            _autorRepository = autorRepository;
        }

        public async Task<AutorWithBooksDTO> Handle(GetAutorByIdRequest request, CancellationToken cancellationToken)
        {            
            var (autor, bookTitles) = await _autorRepository.Get(request.Id, cancellationToken);
            return new AutorWithBooksDTO() { Name = autor.Name, Surname = autor.Surname, Books = bookTitles };
        }
    }
}
