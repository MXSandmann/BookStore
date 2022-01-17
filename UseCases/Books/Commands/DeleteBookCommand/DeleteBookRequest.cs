using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace UseCases.Books.Commands.DeleteBookCommand
{
    public class DeleteBookRequest : IRequest<int>
    {
        public DeleteBookRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
