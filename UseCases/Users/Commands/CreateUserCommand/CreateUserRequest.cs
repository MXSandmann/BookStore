
using MediatR;

namespace UseCases.Users.Commands.CreateUserCommand
{
    public class CreateUserRequest : IRequest<string>
    {
        public CreateUserRequest(string userName, string password, string email, byte role)
        {
            UserName = userName;
            Password = password;
            Email = email;
            Role = role;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte Role { get; set; }
    }
}
