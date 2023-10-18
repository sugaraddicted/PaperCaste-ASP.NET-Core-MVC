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
        Task<ICollection<Author>> GetAuthorsAsync();
        Task<Author> GetByIdAsync(int id);

        ICollection<Book> GetAuthorsBooks(int authorsId);

        bool AuthorExists(int id);

        Task CreateAsync(Author author);

        Task SaveAsync();

        Task UpdateAsync(int id, Author author);

        Task DeleteAsync(Author author);
    }
}
