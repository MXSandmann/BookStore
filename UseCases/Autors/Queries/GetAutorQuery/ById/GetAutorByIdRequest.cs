using MediatR;
using UseCases.DTO.Responses;

namespace UseCases.Autors.Queries.GetAutorQuery.ByID
{
    public class GetAutorByIdRequest : IRequest<AutorWithBooksDTO>
    {
        public GetAutorByIdRequest(int id)
        {
            Id = id;
        }

        public int Id { get; }

    }
}
