using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Autors.Commands.UpdateAutorCommand
{
    public class UpdateAutorRequest : IRequest<int>
    {
        public UpdateAutorRequest(int id)
        {
            Id = id;
        }

        public int Id { get; }
        
    }
}
