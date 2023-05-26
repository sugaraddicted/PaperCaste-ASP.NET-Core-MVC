using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaperCastle.Core;


namespace PaperCastle.Infrastructure.Data.Configurations
{
    public class BookGenreConfiguration : IEntityTypeConfiguration<BookGenre>
    {
        public void Configure(EntityTypeBuilder<BookGenre> builder)
        {
            builder.HasKey(bg => new
            {
                bg.BookId,
                bg.GenreId
            });

            builder.HasOne(b => b.Book)
                 .WithMany(bg => bg.BookGenres)
                 .HasForeignKey(b => b.BookId);

            builder.HasOne(g => g.Genre)
                .WithMany(bg => bg.BookGenres)
                .HasForeignKey(g => g.GenreId);
        }
    }
}
