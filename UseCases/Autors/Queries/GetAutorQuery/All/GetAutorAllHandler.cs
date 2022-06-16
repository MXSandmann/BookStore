using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess;
using Domain;
using Domain.Exceptions;
using Infrastructure.Specification.Autors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UseCases.Common;
using UseCases.DTO.Responses; 

namespace UseCases.Autors.Queries.GetAutorQuery.All
{
    public class GetAutorAllHandler : IRequestHandler<GetAutorAllRequest, PaginationResponse<AutorWithBooksDTO>>
    {
        private readonly ApplicationDBContext _dbContext;

        public GetAutorAllHandler(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginationResponse<AutorWithBooksDTO>> Handle(GetAutorAllRequest request, CancellationToken cancellationToken)
        {
            var specification = new AutorFilterSpecification(request.Name, request.Surname);


            // All autors from DB
            var count = await _dbContext.Autors.Where(specification.CreateCriterium()).CountAsync(cancellationToken);

            //Results of your request
            var autors = _dbContext.Autors
                .Include(a => a.Books)
                .Where(specification.CreateCriterium())
                .Skip(request.Offset)
                .Take(request.Limit)
                .AsEnumerable();
                
            

            List<AutorWithBooksDTO> results = new(autors.Count());

            foreach (var autor in autors)
            {                
                List<string> bookTitles = new(autor.Books.Count);
                foreach (var book in autor.Books)
                    bookTitles.Add(book.Title);
                results.Add(new AutorWithBooksDTO() { ID = autor.ID, Name = autor.Name, Surname = autor.Surname, Books = bookTitles });
            }
            return new PaginationResponse<AutorWithBooksDTO>(results, count);
        }
    }
}
