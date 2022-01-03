using MediatR;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Books.Commands.CreateBookCommand
{
    public class CreateBookRequest : IRequest<int>
    {
        public CreateBookRequest(string title,
            string description,
            int pagesCount,
            int year,
            double price,
            List<Autor> autors,
            List<Genre> genres)
        {
            Title = title;
            Description = description;
            PagesCount = pagesCount;
            Year = year;
            Price = price;
            Autors = autors;
            Genres = genres;
        }

        public string Title { get; }
        public string Description { get; }
        public int PagesCount { get; }
        public int Year { get; }
        public double Price { get; }
        public List<Autor> Autors { get; }
        public List<Genre> Genres { get; }
    }
}
