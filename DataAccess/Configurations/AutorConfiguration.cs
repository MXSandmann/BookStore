using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
