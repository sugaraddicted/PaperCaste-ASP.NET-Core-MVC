using System;
using System.Collections;
using System.Collections.Generic;

namespace PaperCastle.Core.Entity
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImageURL { get; set; }
        public int? YearOfWriting { get; set; }
        public int? AuthorId { get; set; }   
        public Author Author { get; set; }
        public int? CountryId { get; set; }  
        public Country Country { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<BookshelfBook> BookshelfBooks { get; set; }

    }
}
