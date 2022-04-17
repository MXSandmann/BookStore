using MediatR;
using System.Collections.Generic;
using UseCases.Common;
using UseCases.DTO.Responses;

namespace UseCases.Autors.Queries.GetAutorQuery.All
{
    public class GetAutorAllRequest : IRequest<PaginationResponse<AutorWithBooksDTO>>
    {
        public int offset { get; set; }
        public int limit { get; set; }

        public string name { get; set; }
        public string surname { get; set; }
        public GetAutorAllRequest(int offset, int limit, string name, string surname)
        {
            this.offset = offset;
            this.limit = limit;
            this.name = name;
            this.surname = surname;
        }
    }
}
