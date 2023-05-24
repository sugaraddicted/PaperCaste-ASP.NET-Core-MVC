using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCastle.Core
{
    public class UsersBook
    {
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        BookStatus Status { get; set; } 
    }
}
