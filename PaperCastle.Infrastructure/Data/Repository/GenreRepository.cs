using Microsoft.EntityFrameworkCore;
using PaperCastle.Core.Entity;
using PaperCastle.Infrastructure.Data.Intefaces;

namespace PaperCastle.Infrastructure.Data.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _context;

        public GenreRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Genre genre)
        {
            _context.Add(genre);
            await SaveAsync();
        }

        public async Task DeleteAsync(Genre genre)
        {
            _context.Remove(genre);
            await SaveAsync();
        }

        public bool GenreExists(int id)
        {
            return _context.Genres.Any(x => x.Id == id);
        }

        public async Task<ICollection<Book>> GetBooksByGenreAsync(int genreId)
        {
            return await _context.BookGenres
                .Where(e => e.GenreId == genreId)
                .Select(a => a.Book)
                .ToListAsync();
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            return await _context.Genres
                .Where(g => g.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<Genre>> GetGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task UpdateAsync(Genre genre)
        {
            _context.Update(genre);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
