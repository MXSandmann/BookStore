﻿using Domain.Base;
using System.Collections.Generic;

namespace Domain
{
    public class Book : AuditableEntity
    {
        public Book(string title,
            string description,
            int pagesCount,
            int year,
            double price,
            List<Autor> autors,
            List<Genre> genres
            )
        {
            Title = title;
            Description = description;
            PagesCount = pagesCount;
            Year = year;
            Price = price;
            _autors = autors;
            _genres = genres;
        }
        private Book()
        {

        }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int PagesCount { get; private set; }
        public int Year { get; private set; }
        public double Price { get; private set; }
        public IReadOnlyCollection<Autor> Autors => _autors.AsReadOnly();
        private List<Autor> _autors;

        public IReadOnlyCollection<Genre> Genres => _genres.AsReadOnly();
        private List<Genre> _genres;

        public void Update(string title, int pagesCount, int year, double price)
        {
            Title = title;
            PagesCount = pagesCount;
            Year = year;
            Price = price;
        }
    }
}
