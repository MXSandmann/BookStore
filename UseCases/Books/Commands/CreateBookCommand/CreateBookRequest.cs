﻿using MediatR;
using System.Collections.Generic;

namespace UseCases.Books.Commands.CreateBookCommand
{
    public class CreateBookRequest : IRequest<int>
    {
        public CreateBookRequest(string title,
            string description,
            int pagesCount,
            int year,
            double price,
            List<int> autors,
            List<int> genres)
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
        public List<int> Autors { get; }
        public List<int> Genres { get; }
    }
}
