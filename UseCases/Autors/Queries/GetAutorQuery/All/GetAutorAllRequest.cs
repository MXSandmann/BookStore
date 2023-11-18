using MediatR;
using UseCases.Common;
using UseCases.DTO.Responses;

namespace UseCases.Autors.Queries.GetAutorQuery.All
{
    public class GetAutorAllRequest : IRequest<PaginationResponse<AutorWithBooksDTO>>
    {
        public int Offset { get; set; }
        public int Limit { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public GetAutorAllRequest(int offset, int limit, string name, string surname)
        {
            Offset = offset;
            Limit = limit;
            Name = name;
            Surname = surname;
        }
    }
}
