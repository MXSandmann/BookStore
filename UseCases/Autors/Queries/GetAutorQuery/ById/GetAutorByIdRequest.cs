using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using UseCases.DTO.Responses;
using Domain;

namespace UseCases.Autors.Queries.GetAutorQuery.ByID
{
    public class GetAutorByIdRequest : IRequest<AutorWithBooksDTO>
    {       
        public GetAutorByIdRequest(int id)
        {
            Id = id;
        }

        public int Id { get; }

    }
}
