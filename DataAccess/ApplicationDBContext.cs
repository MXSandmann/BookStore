using Domain;
using Domain.Base;
using Infrastructure.UserProvider;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApplicationDBContext : DbContext
    {
        private ICurrentUserProvider _currentUserProvider;
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, ICurrentUserProvider currentUserProvider)
            : base(options)
        {
            _currentUserProvider = currentUserProvider;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = this.ChangeTracker.Entries<IAuditableEntity>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                    entry.Entity.Create(_currentUserProvider.UserId());

                if (entry.State == EntityState.Modified)
                    entry.Entity.Update(_currentUserProvider.UserId());
            }
            return base.SaveChangesAsync(cancellationToken);
            
        }
    }
}
