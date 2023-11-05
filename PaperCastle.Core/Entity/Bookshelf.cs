using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCastle.Core.Entity
{
    public class Bookshelf
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }    
        public string Name { get; set; }    
        public ICollection<BookshelfBook> BookshelfBooks { get; set; }
    }
}
