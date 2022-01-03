using MediatR;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Genres.Commands.CreateGenreCommand
{
    public class CreateGenreRequest : IRequest<int>
    {
        public CreateGenreRequest(string name)
        {
            Name = name;
            //Books = books;
        }

        public string Name { get; }
        //public List<Book> Books { get; }

    }
}
