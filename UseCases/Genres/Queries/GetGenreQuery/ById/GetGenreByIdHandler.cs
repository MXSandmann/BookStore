
using MediatR;
using DataAccess;
using Domain;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using UseCases.DTO.Responses;
using Microsoft.EntityFrameworkCore;

namespace UseCases.Genres.Queries.GetGenreQuery.ByID
{
    public class GetGenreByIDHandler : IRequestHandler<GetGenreByIDRequest, GenreDTO>
    {
        private readonly ApplicationDBContext _dbContext;

        public GetGenreByIDHandler(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GenreDTO> Handle(GetGenreByIDRequest request, CancellationToken cancellationToken)
        {

            var genre = await _dbContext.Genres.FirstOrDefaultAsync(g => g.ID == request.Id);

            if (genre == null)
                throw new NotFoundException(typeof(Genre), request.Id);

            return new GenreDTO() { Name = genre.Name };
        }
    }
}
