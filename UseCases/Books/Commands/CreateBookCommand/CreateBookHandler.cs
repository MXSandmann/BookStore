using DataAccess;
using Domain;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UseCases.Books.Commands.CreateBookCommand
{
    public class CreateBookHandler : IRequestHandler<CreateBookRequest, int>
    {
        private ApplicationDBContext dbContext;
        public CreateBookHandler(ApplicationDBContext DbContext)
        {
            dbContext = DbContext;
        }

        public async Task<int> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            // Create a list of autors, which will be added for new book
            List<Autor> autors = new(request.Autors.Count);

            // Find the existing autors in dbContext by the ID, given from dto
            foreach (var autorID in request.Autors)
            {
                var autor = dbContext.Autors.FirstOrDefault(el => el.ID == autorID);
                
                if (autor == null)
                    throw new NotFoundException(typeof(Autor), autorID);

                autors.Add(autor);

            }

            // Create a list of genres, which will be added for new book
            List<Genre> genres = new(request.Genres.Count);

            // Find the existing genres in dbContext by the ID, given from dto
            foreach (var genreID in request.Genres)
            {
                var genre = dbContext.Genres.FirstOrDefault(el => el.ID == genreID);
                if (genre == null)
                    throw new NotFoundException(typeof(Genre), genreID);

                genres.Add(genre);

            }

            // Check if the new book already exists in dbContext
            // For this check the name of the book and the autors
            var existingBook = dbContext.Books.Include(x => x.Autors).
                FirstOrDefault(s => s.Title == request.Title);                        

            
            if ((existingBook != null) && (existingBook.Autors.SequenceEqual(autors)))
            {
                throw new AlreadyExistException(typeof(Book), existingBook.ID);
            }
                                 
            var book = new Book(request.Title,
                request.Description,
                request.PagesCount,
                request.Year,
                request.Price,
                autors,
                genres);

            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
            return book.ID;
        }
    }
}
