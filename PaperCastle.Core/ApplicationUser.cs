using System;
using System.Collections;
using System.Collections.Generic;

namespace PaperCastle.Core
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<ApplicationUser> Friends { get; set; }
        public ICollection<UsersBook> UsersBooks { get; set; }
    }
}
