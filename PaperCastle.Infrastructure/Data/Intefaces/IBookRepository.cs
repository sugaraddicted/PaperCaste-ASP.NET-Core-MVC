using PaperCastle.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PaperCastle.Infrastructure.Data.Intefaces
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
        Book GetBookById(int id);

        Book GetBookByTitle(string title);

        decimal GetBookRating(int bookId);

        bool CreateBook(Book book);

        bool BookExists(int id);

        bool UpdateBook(Book book);

        bool DeleteBook(Book book);

        bool Save();
    }
}
