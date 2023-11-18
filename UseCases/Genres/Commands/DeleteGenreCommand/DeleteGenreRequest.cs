using MediatR;

namespace UseCases.Genres.Commands.DeleteGenreCommand
{
    public class DeleteGenreRequest : IRequest<int>
    {
        public DeleteGenreRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
