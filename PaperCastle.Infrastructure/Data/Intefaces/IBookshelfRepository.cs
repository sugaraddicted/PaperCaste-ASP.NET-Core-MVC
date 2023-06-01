using PaperCastle.Core;
using PaperCastle.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCastle.Infrastructure.Data.Intefaces
{
    public interface IBookshelfRepository { 
        Bookshelf GetBookshelfById(int id);

        ICollection<Book> GetBooksFromBookshelf(int bookshelfId);

        bool AddBookToBookshelf(int bookshelfId, Book book);

        bool RemoveBookFromBookshelf(int bookshelfId, Book book);

        bool CreateBookshelf(Bookshelf bookshelf);

        bool BookshelfExists(int id);

        bool UpdateBookshelf(Bookshelf bookshelf);

        bool DeleteBookshelf(Bookshelf bookshelf);

        bool Save();
    }
}
