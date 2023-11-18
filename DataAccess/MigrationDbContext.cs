using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess.EF
{
    public class MigrationDbContext : IDesignTimeDbContextFactory<ApplicationDBContext>
    {
        public ApplicationDBContext CreateDbContext(string[] args)
        {
            var optBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            optBuilder.UseSqlServer("Server=DESKTOP-G5UDAJT\\SQLEXPRESS;Database=AppDB;Trusted_Connection=True;");

            return new ApplicationDBContext(optBuilder.Options, default);
        }
    }
}
