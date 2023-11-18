using MediatR;

namespace UseCases.Autors.Commands.UpdateAutorCommand
{
    public class UpdateAutorRequest : IRequest<int>
    {
        public UpdateAutorRequest(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }

        public int Id { get; }
        public string Name { get; }
        public string Surname { get; }

    }
}
