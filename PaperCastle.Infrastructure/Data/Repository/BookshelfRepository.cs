using Microsoft.EntityFrameworkCore;
using PaperCastle.Core;
using PaperCastle.Core.Entity;
using PaperCastle.Infrastructure.Data.Intefaces;

namespace PaperCastle.Infrastructure.Data.Repository
{
    public class BookshelfRepository : IBookshelfRepository
    {
        private readonly DataContext _context;

        public BookshelfRepository(DataContext context)
        {
            _context = context;
        }
        public bool AddBookToBookshelf(int bookshelfId, Book book)
        {
            var shelf = _context.Bookshelves.Where(x => x.Id == bookshelfId).FirstOrDefault();

            if (shelf == null)
                return false;

            shelf.BookshelfBooks.Add(new BookshelfBook
            {
                BookshelfId = bookshelfId,
                BookId = book.Id
            });

            return Save();
        }

        public bool BookshelfExists(int id)
        {
            return _context.Bookshelves.Any(a => a.Id == id);
        }

        public bool CreateBookshelf(Bookshelf bookshelf)
        {
            _context.Add(bookshelf);
            return Save();  
        }

        public bool DeleteBookshelf(Bookshelf bookshelf)
        {
            _context.Remove(bookshelf);
            return Save();  
        }

        public ICollection<Book> GetBooksFromBookshelf(int bookshelfId)
        {
            var books = _context.BookshelfBooks
                .Include(bb => bb.Book)
                .Where(bb => bb.BookshelfId == bookshelfId)
                .Select(bb => bb.Book)
                .ToList();

            return books;
        }

        public Bookshelf GetBookshelfById(int id)
        {
            return _context.Bookshelves.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool RemoveBookFromBookshelf(int bookshelfId, Book book)
        {
            var shelf = _context.Bookshelves.Where(x => x.Id == bookshelfId).FirstOrDefault();

            if (shelf == null)
                return false;

            var bookshelfBook = shelf.BookshelfBooks.FirstOrDefault(x => x.BookId == book.Id);

            if (bookshelfBook == null)
                return false;

            shelf.BookshelfBooks.Remove(bookshelfBook);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateBookshelf(Bookshelf bookshelf)
        {
            _context.Update(bookshelf);
            return Save();  
        }
    }
}
