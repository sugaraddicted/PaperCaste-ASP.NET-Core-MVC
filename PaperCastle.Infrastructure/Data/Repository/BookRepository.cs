using PaperCastle.Core;
using PaperCastle.Core.Entity;
using PaperCastle.Infrastructure.Data.Intefaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PaperCastle.Infrastructure.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Book> GetBooks()
        {
          return _context.Books.OrderBy(p => p.Id).ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.Where(b => b.Id == id).FirstOrDefault();
        }

        public Book GetBookByTitle(string title)
        {
            return _context.Books.Where(b => b.Title == title).FirstOrDefault();
        }

        public decimal GetBookRating(int bookId)
        {
            var review = _context.Reviews.Where(r => r.Book.Id == bookId);

            if (review.Count() <= 0) return 0;

            return ((decimal)review.Sum(r => r.Rating)) / review.Count();
        }

        public bool CreateBook(ICollection<int> genreIds, int yearOfWriting, string description, string coverImageURL, string authorName, string countryName, Book book)
        {
            var bookGenres = _context.Genres.Where(g => genreIds.Contains(g.Id)).ToList();

            book.Author = _context.Authors.FirstOrDefault(a => a.Name == authorName);
            book.Country = _context.Countries.FirstOrDefault(c => c.Name == countryName);
            book.YearOfWriting = yearOfWriting;
            book.Description = description;
            book.CoverImageURL = coverImageURL;

            foreach (var genre in bookGenres)
            {
                var bookGenre = new BookGenre
                {
                    Genre = genre,
                    Book = book
                };

                book.BookGenres.Add(bookGenre);
            }

            _context.Add(book);

            return Save();
        }

        public bool BookExists(int id)
        {
            return _context.Books.Any(a => a.Id == id);
        }
        public bool UpdateBook(Book book)
        {
            _context.Update(book);
            return Save();
        }

        public bool DeleteBook(Book book)
        {
            _context.Remove(book);
            return Save();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }
    }
}
