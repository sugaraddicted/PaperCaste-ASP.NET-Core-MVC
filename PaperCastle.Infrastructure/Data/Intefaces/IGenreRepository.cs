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
        ICollection<Genre> GetGenres();
        Genre GetGenreById(int id);

        ICollection<Book> GetBooksByGenre(int genreId);

        bool GenreExists(int id);

        bool CreateGenre(Genre genre);

        bool Save();

        bool UpdateGenre(Genre genre);

        bool DeleteGenre(Genre genre);
    }
}
