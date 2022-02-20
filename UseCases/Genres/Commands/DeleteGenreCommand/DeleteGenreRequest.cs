using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Genres.Commands.DeleteGenreCommand
{
    public class DeleteGenreRequest : IRequest<int>
    {
        public DeleteGenreRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
