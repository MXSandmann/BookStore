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
        }

        public string Name { get; }
    }
}
