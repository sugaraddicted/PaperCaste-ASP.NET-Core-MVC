using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaperCastle.Core;
using PaperCastle.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCastle.Infrastructure.Data.Configurations
{
    public class BookshelfBookConfiguraion : IEntityTypeConfiguration<BookshelfBook>
    {
        public void Configure(EntityTypeBuilder<BookshelfBook> builder)
        {
            builder.HasKey(bb => new
            {
                bb.BookId,
                bb.BookshelfId
            });

            builder.HasOne(bb => bb.Book)
                .WithMany(b => b.BookshelfBooks)
                .HasForeignKey(bb => bb.BookId);

            builder.HasOne(bb => bb.Bookshelf)
                   .WithMany(bs => bs.BookshelfBooks)
                   .HasForeignKey(bb => bb.BookshelfId);
        }
    }
}
