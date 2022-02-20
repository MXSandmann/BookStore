using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Autors.Commands.DeleteAutorCommand
{
    public class DeleteAutorRequest : IRequest<int>
    {
        public DeleteAutorRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
