using MediatR;

namespace UseCases.Autors.Commands.CreateAutorCommand
{
    public class CreateAutorRequest : IRequest<int>
    {
        public CreateAutorRequest(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string Name { get; }
        public string Surname { get; }
    }
}
