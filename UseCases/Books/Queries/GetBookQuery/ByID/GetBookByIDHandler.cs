using DataAccess;
using Domain;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UseCases.DTO.Responses;

namespace UseCases.Books.Queries.GetBookByID
{
    public class GetBookByIDHandler : IRequestHandler<GetBookByIDRequest, BookDTO>
    {
        private readonly ApplicationDBContext _dbContext;

        public GetBookByIDHandler(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookDTO> Handle(GetBookByIDRequest request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.Include(b => b.Autors).Include(b => b.Genres).FirstOrDefaultAsync(b => b.ID == request.Id);
            if (book == null)
                throw new NotFoundException(typeof(Book), request.Id);

            // Add all autors of this book as a structure
            List<AutorDTO> autorsOfBook = new(book.Autors.Count);
            foreach (var autor in book.Autors)
            {
                autorsOfBook.Add(new() { Name = autor.Name, Surname = autor.Surname });
            }

            // Add all genres of this book as list of strings
            List<string> genresOfBook = new(book.Genres.Count);
            foreach (var genre in book.Genres)
            {
                genresOfBook.Add(genre.Name);
            }

            return new BookDTO()
            {
                Title = book.Title,
                Description = book.Description,
                PagesCount = book.PagesCount,
                Year = book.Year,
                Price = book.Price,
                Autors = autorsOfBook,
                Genres = genresOfBook
            };
        }
    }
}
