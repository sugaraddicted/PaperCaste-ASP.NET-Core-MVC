﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PaperCastle.Core.Entity;

namespace PaperCastle.Core
{
    public class BookGenre
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }
        public Book Book { get; set; }
        public Genre Genre { get; set; }
    }
}
