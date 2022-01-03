using System.Collections.Generic;
using Domain;

namespace WebApp.DTO.Requests
{
    public class CreateBookDTO
    {
        public string Title { get; }
        public string Description { get; }
        public int PagesCount { get; }
        public int Year { get; }
        public double Price { get; }
        public List<Autor> Autors { get; }
        public List<Genre> Genres { get; }
    }
}
