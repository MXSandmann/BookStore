using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class AutorConfiguration : IEntityTypeConfiguration<Autor>
    {
        void IEntityTypeConfiguration<Autor>.Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.HasKey(x => x.ID);

            builder.HasMany(x => x.Books).WithMany(x => x.Autors);
            builder.Metadata.FindNavigation(nameof(Autor.Books)).SetField("_books");

            builder.ToTable("Autors");
        }
    }
}
