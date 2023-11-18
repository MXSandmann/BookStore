using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(x => x.ID);

            builder.HasMany(x => x.Books).WithMany(x => x.Genres);
            builder.Metadata.FindNavigation(nameof(Genre.Books)).SetField("_books");

            builder.ToTable("Genres");
        }
    }
}
