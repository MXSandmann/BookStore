using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EF
{
    public class MigrationDbContext : IDesignTimeDbContextFactory<ApplicationDBContext>
    {
        public ApplicationDBContext CreateDbContext(string[] args)
        {
            var optBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            optBuilder.UseSqlServer("Server=DESKTOP-G5UDAJT\\SQLEXPRESS;Database=AppDB;Trusted_Connection=True;");

            return new ApplicationDBContext(optBuilder.Options);
        }
    }
}
