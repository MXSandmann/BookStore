using MediatR;
using System.Collections.Generic;
using UseCases.DTO.Responses;

namespace UseCases.Books.Queries.GetBookAll
{
    public class GetBookAllRequest : IRequest<IEnumerable<BookDTO>>
    {
        public GetBookAllRequest()
        {

        }
    }
}
