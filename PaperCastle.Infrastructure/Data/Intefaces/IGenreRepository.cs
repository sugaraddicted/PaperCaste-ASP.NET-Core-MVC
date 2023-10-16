using PaperCastle.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PaperCastle.Infrastructure.Data.Intefaces
{
    public interface IGenreRepository
    {
        Task<ICollection<Genre>> GetGenresAsync();
        Task<Genre> GetByIdAsync(int id);
        Task<ICollection<Book>> GetBooksByGenreAsync(int genreId);
        bool GenreExists(int id);
        Task CreateAsync(Genre genre);
        Task SaveAsync();
        Task UpdateAsync(int id, Genre genre);
        Task DeleteAsync(Genre genre);
    }
}
