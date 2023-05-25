

using Microsoft.EntityFrameworkCore;
using PaperCastle.Core;

namespace PaperCastle.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersBook>().HasKey(ub => new
            {
                ub.ApplicationUserId,
                ub.BookId
            });

            modelBuilder.Entity<BookGenre>().HasKey(bg => new
            {
                bg.BookId,
                bg.GenreId
            });

            modelBuilder.Entity<UsersBook>()
                 .HasOne(u => u.ApplicationUser)
                 .WithMany(ub => ub.UsersBooks)
                 .HasForeignKey(au =>au.ApplicationUserId);
            modelBuilder.Entity<UsersBook>()
                 .HasOne(b => b.Book)
                 .WithMany(ub => ub.UsersBooks)
                 .HasForeignKey(b =>b.BookId);

         
            modelBuilder.Entity<BookGenre>()
                .HasOne(b => b.Book)
                .WithMany(bg => bg.BookGenres)
                .HasForeignKey(b => b.BookId);
            modelBuilder.Entity<BookGenre>()
                .HasOne(g => g.Genre)
                .WithMany(bg => bg.BookGenres)
                .HasForeignKey(g => g.GenreId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }     
        public DbSet<Author> Authors { get; set; }
        public DbSet<Country> Countries { get; set; }   
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<UsersBook> UsersBooks { get; set; }

    }
}
