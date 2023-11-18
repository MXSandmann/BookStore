using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UseCases.DTO.Responses;

namespace UseCases.Books.Queries.GetBookAll
{
    public class GetBookAllHandler : IRequestHandler<GetBookAllRequest, IEnumerable<BookDTO>>
    {
        private readonly ApplicationDBContext _dbContext;

        public GetBookAllHandler(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<BookDTO>> Handle(GetBookAllRequest request, CancellationToken cancellationToken)
        {
            var books = await _dbContext.Books.Include(b => b.Autors).Include(b => b.Genres).ToListAsync();

            List<BookDTO> results = new(books.Count);

            foreach (var book in books)
            {
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

                results.Add(new()
                {
                    ID = book.ID,
                    Title = book.Title,
                    Description = book.Description,
                    PagesCount = book.PagesCount,
                    Year = book.Year,
                    Price = book.Price,
                    Autors = autorsOfBook,
                    Genres = genresOfBook
                });
            }
            return results;
        }
    }
}
