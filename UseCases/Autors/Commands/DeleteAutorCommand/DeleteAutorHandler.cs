using DataAccess.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Autors.Commands.DeleteAutorCommand
{
    public class DeleteAutorHandler : IRequestHandler<DeleteAutorRequest, int>
    {
        private readonly IAutorRepository _autorRepository;

        public DeleteAutorHandler(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<int> Handle(DeleteAutorRequest request, CancellationToken cancellationToken)
        {
            var deletedId = await _autorRepository.Delete(request.Id, cancellationToken);
            return deletedId;
        }
    }
}
