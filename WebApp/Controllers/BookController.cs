﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UseCases.Books.Commands.CreateBookCommand;
using UseCases.Books.Commands.DeleteBookCommand;
using UseCases.Books.Commands.UpdateBookRequest;
using UseCases.Books.Queries.GetBookAll;
using UseCases.Books.Queries.GetBookByID;
using UseCases.DTO.Responses;
using WebApp.DTO.Requests;
using WebApp.DTO.Responses;

namespace WebApp.Controllers
{
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator Mediator)
        {
            _mediator = Mediator;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<APIResponse<int>> CreateBook([FromBody] CreateBookDTO dto)
        {
            var result = await _mediator.Send(new CreateBookRequest(dto.Title,
                dto.Description,
                dto.PagesCount,
                dto.Year,
                dto.Price,
                dto.Autors,
                dto.Genres));
            return APIResponse<int>.OK(result);
        }

        [HttpGet("get")]
        public async Task<APIResponse<IEnumerable<BookDTO>>> GetAllBooks()
        {
            var result = await _mediator.Send(new GetBookAllRequest());
            return APIResponse<IEnumerable<BookDTO>>.OK(result);
        }

        [HttpGet("get/{id}")]
        public async Task<APIResponse<BookDTO>> GetBookById(int id)
        {
            var result = await _mediator.Send(new GetBookByIDRequest(id));
            return APIResponse<BookDTO>.OK(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<APIResponse<int>> DeleteBook(int id)
        {
            var result = await _mediator.Send(new DeleteBookRequest(id));
            return APIResponse<int>.OK(result);
        }

        [HttpPut("update")]
        public async Task<APIResponse<int>> UpdateBook([FromBody] UpdateBookDTO dto)
        {
            var result = await _mediator.Send(new UpdateBookRequest(dto.Id, dto.Title, dto.Price, dto.PagesCount, dto.Year));
            return APIResponse<int>.OK(result);
        }
    }
}
