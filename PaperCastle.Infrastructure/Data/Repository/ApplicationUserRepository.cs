using Microsoft.EntityFrameworkCore;
using PaperCastle.Core.Entity;
using PaperCastle.Infrastructure.Data.Intefaces;


namespace PaperCastle.Infrastructure.Data.Repository
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly DataContext _context;

        public ApplicationUserRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddUser(ApplicationUser user)
        {
            _context.ApplicationUsers.Add(user);
            return Save();
        }

        public bool DeleteUser(ApplicationUser user)
        {
            _context.Remove(user);
            return Save();
        }

        public ApplicationUser GetUserById(int id)
        {
            return _context.ApplicationUsers.Where(a => a.Id == id).FirstOrDefault();
        }

        public ICollection<ApplicationUser> GetUsers()
        {
            return _context.ApplicationUsers.ToList();
        }

        public ICollection<Bookshelf> GetUsersBookshelves(int userId)
        {
            var user = _context.ApplicationUsers.Include(a => a.Bookshelves).FirstOrDefault(a => a.Id == userId);
            return user?.Bookshelves.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUser(ApplicationUser user)
        {
            _context.Update(user);
            return Save();
        }

        public bool UserExists(int id)
        {
            return _context.ApplicationUsers.Any(a => a.Id == id);
        }
    }
}
