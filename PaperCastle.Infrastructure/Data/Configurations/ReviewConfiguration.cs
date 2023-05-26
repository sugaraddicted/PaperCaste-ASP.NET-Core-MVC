using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaperCastle.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCastle.Infrastructure.Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasOne(x => x.ApplicationUser)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.ApplicationUserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(x => x.Book)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.BookId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
