using Domain;
using Infrastructure.Specification.Autors;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IAutorRepository
    {
        Task<(Autor, List<string>)> Get(int id, CancellationToken cancellationToken = default);
        Task<(IEnumerable<Autor>, int)> GetAll(AutorFilterSpecification specification, int offset, int limit, CancellationToken cancellationToken = default);
    }
}
