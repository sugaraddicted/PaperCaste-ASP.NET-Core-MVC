using PaperCastle.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PaperCastle.Infrastructure.Data.Intefaces
{
    public interface IAuthorRepository
    {
        ICollection<Author> GetAuthors();
        Author GetAuthorById(int id);

        ICollection<Book> GetAuthorsBooks(int authorsId);

        bool AuthorExists(int id);

        bool CreateAuthor(Author author);

        bool Save();

        bool UpdateAuthor(Author author);

        bool DeleteAuthor(Author author);
    }
}
