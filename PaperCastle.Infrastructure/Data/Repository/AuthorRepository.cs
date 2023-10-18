using PaperCastle.Core.Entity;
using PaperCastle.Infrastructure.Data.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace PaperCastle.Infrastructure.Data.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Book> GetAuthorsBooks(int authorId)
        {
            var author = _context.Authors.Include(a => a.Books).FirstOrDefault(a => a.Id == authorId);
            return author?.Books.ToList();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _context.Authors.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Author>> GetAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public bool AuthorExists(int id)
        {
            return _context.Authors.Any(a => a.Id == id);
        }

        public async Task CreateAsync(Author author)
        {
            _context.Add(author);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Author updatesdAuthor)
        {
            var author = await GetByIdAsync(id);
            author.Name = updatesdAuthor.Name;
            author.Bio = updatesdAuthor.Bio;
            author.PictureURL = updatesdAuthor.PictureURL;
            author.CountryId = updatesdAuthor.CountryId;
            _context.Update(author);
            await SaveAsync();
        }

        public async Task DeleteAsync(Author author)
        {
            _context.Remove(author);
            await SaveAsync();
        }
    }
}
