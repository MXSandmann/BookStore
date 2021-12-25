using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Books.Commands.CreateBookCommand
{
    public class CreateBookHandler : IRequestHandler<CreateBookRequest, int>
    {
        public Task<int> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
