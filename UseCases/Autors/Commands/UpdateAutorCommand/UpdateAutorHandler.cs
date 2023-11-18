using DataAccess.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Autors.Commands.UpdateAutorCommand
{
    public class UpdateAutorHandler : IRequestHandler<UpdateAutorRequest, int>
    {
        private readonly IAutorRepository _autorRepository;
        public UpdateAutorHandler(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }
        public async Task<int> Handle(UpdateAutorRequest request, CancellationToken cancellationToken)
        {
            var updatedId = await _autorRepository.Update(request.Id, request.Name, request.Surname, cancellationToken);
            return updatedId;
        }
    }
}
