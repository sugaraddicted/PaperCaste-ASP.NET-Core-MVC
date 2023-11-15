using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PaperCastle.Core.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<ApplicationUser> Friends { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Bookshelf> Bookshelves { get; set; }
    }
}
