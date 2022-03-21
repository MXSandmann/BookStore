using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Autor : Entity
    {
        public Autor(string name, string surname)
        {
            Name = name;
            Surname = surname;    
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
