using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PaperCastle.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCastle.Infrastructure.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasOne(x => x.Country)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.CountryId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.AuthorId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
