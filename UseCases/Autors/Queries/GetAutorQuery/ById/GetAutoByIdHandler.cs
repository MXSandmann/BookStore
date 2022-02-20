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
        private ApplicationDBContext dBContext;

        public GetAutoByIdHandler(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<AutorWithBooksDTO> Handle(GetAutorByIdRequest request, CancellationToken cancellationToken)
        {
            var autor = await dBContext.Autors.Include(a => a.Books).FirstOrDefaultAsync(a => a.ID == request.Id);
            if (autor == null)
                throw new NotFoundException(typeof(Autor), request.Id);
            
            List<string> bookTitles = new(autor.Books.Count);
            foreach (var book in autor.Books)
                bookTitles.Add(book.Title);

            return new AutorWithBooksDTO() { Name = autor.Name, Surname = autor.Surname, Books = bookTitles };
        }
    }
}