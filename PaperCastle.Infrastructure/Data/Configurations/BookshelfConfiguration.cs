using Microsoft.EntityFrameworkCore;
using PaperCastle.Core.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PaperCastle.Infrastructure.Data.Configurations
{
    public class BookshelfConfiguration : IEntityTypeConfiguration<Bookshelf>
    {
        public void Configure(EntityTypeBuilder<Bookshelf> builder)
        {
            builder.HasOne(b => b.ApplicationUser)
                .WithMany(u => u.Bookshelves)
                .HasForeignKey(x => x.ApplicationUserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
