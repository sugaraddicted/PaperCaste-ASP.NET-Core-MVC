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

        public Author GetAuthorById(int id)
        {
            return _context.Authors.Where(a => a.Id == id).FirstOrDefault();
        }

        public ICollection<Author> GetAuthors()
        {
            return _context.Authors.ToList();
        }

        public bool AuthorExists(int id)
        {
            return _context.Authors.Any(a => a.Id == id);
        }

        public bool CreateAuthor(Author author)
        {
            _context.Add(author);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAuthor(Author author)
        {
            _context.Update(author);
            return Save();
        }

        public bool DeleteAuthor(Author author)
        {
            _context.Remove(author);
            return Save();
        }
    }
}
