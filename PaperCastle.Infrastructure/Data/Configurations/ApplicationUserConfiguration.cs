using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaperCastle.Core.Entity;
using System.Reflection.Emit;

namespace PaperCastle.Infrastructure.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasOne(x => x.Country)
                .WithMany(x => x.ApplicationUsers)
                .HasForeignKey(x => x.CountryId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.Friends)
                .WithMany()
                .UsingEntity(j => j.ToTable("UserFriends"));
        }
    }
}