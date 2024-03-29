﻿using Infrastructure.UserProvider;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UseCases.Users.Commands.CreateUserCommand;
using UseCases.Users.Commands.LoginUserCommand;
using UseCases.Users.DTO;
using WebApp.DTO.Requests;

namespace WebApp.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserProvider _currentUserProvider;
        public UserController(IMediator Mediator, ICurrentUserProvider CurrentUserProvider)
        {
            _mediator = Mediator;
            _currentUserProvider = CurrentUserProvider;
        }
        [HttpPost("create")]
        public async Task<string> CreateUser([FromBody] CreateUserDTO dto)
        {
            var result = await _mediator.Send(new CreateUserRequest(dto.UserName, dto.Password, dto.Email, dto.Role));
            return result;
        }
        [HttpPost("login")]
        public async Task<LoginResultDTO> LoginUser([FromBody] LoginDTO dto)
        {
            var result = await _mediator.Send(new LoginUserRequest(dto.UserName, dto.Password));
            return result;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public int Test()
        {
            return _currentUserProvider.UserId();
        }
    }
}
