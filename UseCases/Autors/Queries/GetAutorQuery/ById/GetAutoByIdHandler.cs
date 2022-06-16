﻿using DataAccess;
using Domain;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UseCases.DTO.Responses;

namespace UseCases.Autors.Queries.GetAutorQuery.ByID
{
    public class GetAutoByIdHandler : IRequestHandler<GetAutorByIdRequest, AutorWithBooksDTO>
    {
        private readonly ApplicationDBContext _dBContext;

        public GetAutoByIdHandler(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<AutorWithBooksDTO> Handle(GetAutorByIdRequest request, CancellationToken cancellationToken)
        {
            var autor = await _dBContext.Autors.Include(a => a.Books).FirstOrDefaultAsync(a => a.ID == request.Id);
            if (autor == null)
                throw new NotFoundException(typeof(Autor), request.Id);
            
            List<string> bookTitles = new(autor.Books.Count);
            foreach (var book in autor.Books)
                bookTitles.Add(book.Title);

            return new AutorWithBooksDTO() { Name = autor.Name, Surname = autor.Surname, Books = bookTitles };
        }

        public async Task<AutorDTO> HandleFind(GetAutorByIdRequest request, CancellationToken cancellationToken)
        {
            var autor = await _dBContext.Autors.FindAsync(request.Id);//FirstOrDefaultAsync(a => a.ID == request.Id);
            if (autor == null)
                throw new NotFoundException(typeof(Autor), request.Id);

            

            return new AutorDTO() { Name = autor.Name, Surname = autor.Surname };
        }
    }
}
