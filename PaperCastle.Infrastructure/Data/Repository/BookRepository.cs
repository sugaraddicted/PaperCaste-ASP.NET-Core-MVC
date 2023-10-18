using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PaperCastle.Core;
using PaperCastle.Core.Entity;
using PaperCastle.Infrastructure.Data.Intefaces;

namespace PaperCastle.Infrastructure.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Book>> GetBooksAsync()
        {
            return await _context.Books.OrderBy(p => p.Id)
                                      .Include(b => b.Author)
                                      .ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var book = await _context.Books.Where(b => b.Id == id)
                                    .Include(b => b.Author)
                                    .Include(b => b.Country)
                                    .Include(b => b.Reviews)
                                    .Include(b => b.BookGenres)
                                    .Include(b => b.BookshelfBooks)
                                    .FirstOrDefaultAsync();
            return book;
        }

        public async Task<Book> GetBookByTitleAsync(string title)
        {
            var book = await _context.Books.Where(b => b.Title == title).FirstOrDefaultAsync();
            return book;
        }

        public async Task<decimal> GetBookRatingAsync(int bookId)
        {
            var review = await _context.Reviews.Where(r => r.Book.Id == bookId).ToListAsync();

            if (review.Count() <= 0) return 0;

            return ((decimal)review.Sum(r => r.Rating)) / review.Count();
        }

        public async Task CreateAsync(Book book)
        {
            _context.Add(book);
            await SaveAsync();
        }

        public bool BookExists(int id)
        {
            return _context.Books.Any(a => a.Id == id);
        }

        public async Task UpdateAsync(int id, Book updatedBook)
        {
            var book = await _context.Books.Where(b => b.Id == id).FirstOrDefaultAsync();

            if (book == null) 
                throw new Exception("Book not found");
            
            if(!updatedBook.Title.IsNullOrEmpty())
                           book.Title = updatedBook.Title;
            await _context.BookGenres.Where(bg => bg.BookId == book.Id).ExecuteDeleteAsync();

            book.AuthorId = updatedBook.AuthorId;
            book.Description = updatedBook.Description;
            book.BookGenres = updatedBook.BookGenres;
            book.CountryId = updatedBook.CountryId;
            book.CoverImageURL = updatedBook.CoverImageURL;
            book.YearOfWriting = updatedBook.YearOfWriting;

            _context.Update(book);
            await SaveAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            _context.Remove(book);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
