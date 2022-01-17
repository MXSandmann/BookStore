using MediatR;
using UseCases.DTO.Responses;

namespace UseCases.Genres.Queries.GetGenreQuery.ByID
{
    public class GetGenreByIDRequest : IRequest<GenreDTO>
    {
        public GetGenreByIDRequest(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
