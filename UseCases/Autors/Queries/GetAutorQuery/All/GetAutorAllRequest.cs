using MediatR;
using System.Collections.Generic;
using UseCases.DTO.Responses;

namespace UseCases.Autors.Queries.GetAutorQuery.All
{
    public class GetAutorAllRequest : IRequest<IEnumerable<AutorWithBooksDTO>>
    {
        public GetAutorAllRequest()
        {

        }
    }
}
