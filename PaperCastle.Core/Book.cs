using System;
using System.Collections;
using System.Collections.Generic;

namespace PaperCastle.Core
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImageURL { get; set; }
        public int YearOfWriting { get; set; }
        public Country Country { get; set; }    
        public ICollection<Genre> Genres { get; set; }

    }
}
