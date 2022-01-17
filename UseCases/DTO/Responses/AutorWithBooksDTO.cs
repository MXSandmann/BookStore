using System.Collections.Generic;

namespace UseCases.DTO.Responses
{
    public class AutorWithBooksDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public IEnumerable<string> Books { get; set; }
    }
}
