using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCastle.Application.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImageURL { get; set; }
        public int YearOfWriting { get; set; }
        public int? AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int? CountryId { get; set; }
        public string CountryName { get; set; }
    }

}
