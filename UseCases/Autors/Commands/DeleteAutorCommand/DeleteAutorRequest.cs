using MediatR;

namespace UseCases.Autors.Commands.DeleteAutorCommand
{
    public class DeleteAutorRequest : IRequest<int>
    {
        public DeleteAutorRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
