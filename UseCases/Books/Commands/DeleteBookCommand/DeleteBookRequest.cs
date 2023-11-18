using MediatR;

namespace UseCases.Books.Commands.DeleteBookCommand
{
    public class DeleteBookRequest : IRequest<int>
    {
        public DeleteBookRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
