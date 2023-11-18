using System.Collections.Generic;

namespace Domain
{
    public class Genre : Entity
    {
        public Genre(string name)
        {
            Name = name;

        }
        private Genre()
        {

        }
        public string Name { get; private set; }
        public IReadOnlyCollection<Book> Books => _books.AsReadOnly();
        private List<Book> _books;
    }
}
