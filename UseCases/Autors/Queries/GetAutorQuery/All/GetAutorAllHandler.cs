using DataAccess.Contracts;
using Infrastructure.Specification.Autors;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Common;
using UseCases.DTO.Responses;

namespace UseCases.Autors.Queries.GetAutorQuery.All
{
    public class GetAutorAllHandler : IRequestHandler<GetAutorAllRequest, PaginationResponse<AutorWithBooksDTO>>
    {
        private readonly IAutorRepository _autorRepository;

        public GetAutorAllHandler(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<PaginationResponse<AutorWithBooksDTO>> Handle(GetAutorAllRequest request, CancellationToken cancellationToken)
        {
            var specification = new AutorFilterSpecification(request.Name, request.Surname);

            var (autors, count) = await _autorRepository.GetAll(specification, request.Offset, request.Limit, cancellationToken);

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
