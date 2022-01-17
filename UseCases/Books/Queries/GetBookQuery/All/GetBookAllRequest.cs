using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UseCases.DTO.Responses;

namespace UseCases.Books.Queries.GetBookAll
{
    public class GetBookAllRequest : IRequest<IEnumerable<BookDTO>>
    {
        public GetBookAllRequest()
        {

        }
    }
}
