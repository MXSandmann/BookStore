using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess;
using Domain;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UseCases.DTO.Responses; 

namespace UseCases.Autors.Queries.GetAutorQuery.All
{
    public class GetAutorAllHandler : IRequestHandler<GetAutorAllRequest, IEnumerable<AutorWithBooksDTO>>
    {
        private ApplicationDBContext dbContext;

        public GetAutorAllHandler(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AutorWithBooksDTO>> Handle(GetAutorAllRequest request, CancellationToken cancellationToken)
        {
            var autors = await dbContext.Autors.Include(a => a.Books).ToListAsync();
            //if (autors == null)
            //    throw new NotFoundException(typeof(Autor));

            List<AutorWithBooksDTO> results = new(autors.Count);

            foreach (var autor in autors)
            {                
                List<string> bookTitles = new(autor.Books.Count);
                foreach (var book in autor.Books)
                    bookTitles.Add(book.Title);
                results.Add(new AutorWithBooksDTO() { ID = autor.ID, Name = autor.Name, Surname = autor.Surname, Books = bookTitles });
            }
            return results;
        }
    }
}
