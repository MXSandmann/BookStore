using System.Collections.Generic;

namespace Domain
{
    public class Autor : Entity
    {
        public Autor(string name, string surname)
        {
            Name = name;
            Surname = surname;
            _books = new List<Book>();
        }
        private Autor()
        {

        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public IReadOnlyCollection<Book> Books => _books.AsReadOnly();

        private List<Book> _books;

        public void Update(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

    }
}
