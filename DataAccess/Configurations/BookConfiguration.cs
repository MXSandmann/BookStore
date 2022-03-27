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
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.ID);

            builder.HasMany(x => x.Genres).WithMany(x => x.Books);
            builder.HasMany(x => x.Autors).WithMany(x => x.Books);
            builder.Metadata.FindNavigation(nameof(Book.Genres)).SetField("_genres");
            builder.Metadata.FindNavigation(nameof(Book.Autors)).SetField("_autors");

            builder.Property(x => x.CreateDate).HasColumnType("datetime2(0)").HasDefaultValueSql("getdate()"); //datetime2 - Date + time, 0 - signes after coma  
            builder.Property(x => x.UpdateDate).HasColumnType("datetime2(0)");

            builder.ToTable("Books");
        }
    }
}
