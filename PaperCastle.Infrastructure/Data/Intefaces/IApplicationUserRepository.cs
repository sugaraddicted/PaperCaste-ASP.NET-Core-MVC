using PaperCastle.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCastle.Infrastructure.Data.Intefaces
{
    public interface IApplicationUserRepository
    {
        ICollection<ApplicationUser> GetUsers();
        ApplicationUser GetUserById(string id);

        ICollection<Bookshelf> GetUsersBookshelves(string userId);

        bool UserExists(string id);

        bool AddUser(ApplicationUser user);

        bool Save();

        bool UpdateUser(ApplicationUser user);

        bool DeleteUser(ApplicationUser user);
    }
}
