using MediatR;
using UseCases.DTO.Responses;

namespace UseCases.Books.Queries.GetBookByID
{
    public class GetBookByIDRequest : IRequest<BookDTO>
    {
        public GetBookByIDRequest(int id)
        {
            Id = id;
        }

        public int Id;
    }
}
