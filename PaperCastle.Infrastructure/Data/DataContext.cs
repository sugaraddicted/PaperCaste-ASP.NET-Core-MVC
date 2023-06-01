

using Microsoft.EntityFrameworkCore;
using PaperCastle.Core;
using PaperCastle.Core.Entity;
using PaperCastle.Infrastructure.Data.Configurations;

namespace PaperCastle.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BookGenreConfiguration());
            modelBuilder.ApplyConfiguration(new BookshelfConfiguration());
            modelBuilder.ApplyConfiguration(new BookshelfBookConfiguraion());
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }     
        public DbSet<Author> Authors { get; set; }
        public DbSet<Country> Countries { get; set; }   
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Bookshelf> Bookshelves { get; set; }
        public DbSet<BookshelfBook> BookshelfBooks { get; set; }    

    }
}
