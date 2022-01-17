using MediatR;
using System.Collections.Generic;
using UseCases.DTO.Responses;

namespace UseCases.Genres.Queries.GetGenreQuery.All
{
    public class GetGenreAllRequest : IRequest<IEnumerable<GenreDTO>>
    {
        public GetGenreAllRequest()
        {

        }

    }
}
