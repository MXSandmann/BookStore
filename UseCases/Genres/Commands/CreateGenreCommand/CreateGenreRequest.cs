using MediatR;

namespace UseCases.Genres.Commands.CreateGenreCommand
{
    public class CreateGenreRequest : IRequest<int>
    {
        public CreateGenreRequest(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
