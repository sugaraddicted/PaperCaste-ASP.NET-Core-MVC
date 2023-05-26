using PaperCastle.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCastle.Core
{
    public class BookshelfBook
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int BookshelfId { get; set; }
        public Bookshelf Bookshelf { get; set; }

    }
}
