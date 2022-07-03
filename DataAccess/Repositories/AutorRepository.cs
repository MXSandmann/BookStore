using DataAccess.Contracts;
using Domain;
using Domain.Exceptions;
using Infrastructure.Specification.Autors;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly ApplicationDBContext _dbContext;
        
        public AutorRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Autor> Create(string Name, string Surname, CancellationToken cancellationToken = default)
        {
            // Check if the new autor already exists in dbContext
            var existingAutor = await _dbContext.Autors.FirstOrDefaultAsync(s => s.Name == Name && s.Surname == Surname, cancellationToken);

            if (existingAutor != null)
            {
                throw new AlreadyExistException(typeof(Autor), existingAutor.ID);
            }

            var autor = new Autor(Name, Surname);
            await _dbContext.Autors.AddAsync(autor, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
                       
            return autor;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken = default)
        {
            var autor = await _dbContext.Autors.Include(a => a.Books).FirstOrDefaultAsync(a => a.ID == id, cancellationToken);
            _dbContext.Autors.Remove(autor);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return id;
        }

        public async Task<(Autor, List<string>)> Get(int id, CancellationToken cancellationToken)
        {
            var autor = await _dbContext.Autors.Include(a => a.Books).FirstOrDefaultAsync(a => a.ID == id, cancellationToken);
            if (autor == null)
                throw new NotFoundException(typeof(Autor), id);

            List<string> bookTitles = new(autor.Books.Count);
            foreach (var book in autor.Books)
                bookTitles.Add(book.Title);

            return (autor, bookTitles);
        }

        public async Task<(IEnumerable<Autor>, int)> GetAll(AutorFilterSpecification specification, int offset, int limit, CancellationToken cancellationToken)
        {           
            // All autors from DB
            var count = await _dbContext.Autors.Where(specification.CreateCriterium()).CountAsync(cancellationToken);

            //Results of your request
            var autors = _dbContext.Autors
                .Include(a => a.Books)
                .Where(specification.CreateCriterium())
                .Skip(offset)
                .Take(limit)
                .AsEnumerable();
            return (autors, count);
        }

        public async Task<int> Update(int id, string name, string surname, CancellationToken cancellationToken = default)
        {
            var autor = await _dbContext.Autors.FirstOrDefaultAsync(a => a.ID == id, cancellationToken);
            if (autor == null)
                throw new NotFoundException(typeof(Autor), id);

            autor.Update(name, surname);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return autor.ID;
        }
    }
}
