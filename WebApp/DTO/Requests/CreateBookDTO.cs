using System.Collections.Generic;

namespace WebApp.DTO.Requests
{
    public class CreateBookDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PagesCount { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public List<int> Autors { get; set; }
        public List<int> Genres { get; set; }
    }
}
