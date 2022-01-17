
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
using UseCases.Genres.Queries.GetGenreQuery;

namespace UseCases.Genres.Queries.GetGenreQuery.All
{
    public class GetGenreAllHandler : IRequestHandler<GetGenreAllRequest, IEnumerable<GenreDTO>> 
    {
        private ApplicationDBContext dbContext;

        public GetGenreAllHandler(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<GenreDTO>> Handle(GetGenreAllRequest request, CancellationToken cancellationToken)
        {
            var genres = await dbContext.Genres.ToListAsync();

            List<GenreDTO> results = new(genres.Count);
            genres.ForEach(g => results.Add(new GenreDTO() { ID = g.ID, Name = g.Name }));
            return results;
        }
    }
}
