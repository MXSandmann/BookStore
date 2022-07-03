using DataAccess.Contracts;
using Infrastructure.RabbitMq;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Autors.Commands.CreateAutorCommand
{
    public class CreateAutorHandler : IRequestHandler<CreateAutorRequest, int>
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IRabbitMq _rabbitMq;
        public CreateAutorHandler(IRabbitMq RabbitMq, IAutorRepository autorRepository)
        {            
            _rabbitMq = RabbitMq;
            _autorRepository = autorRepository;
        }

        public async Task<int> Handle(CreateAutorRequest request, CancellationToken cancellationToken)
        {            
            var autor = await _autorRepository.Create(request.Name, request.Surname, cancellationToken);
                      
            _rabbitMq.SendMessage("TestExchange", "TestKey", JsonConvert.SerializeObject(autor));

            return autor.ID;
        }
    }
}
