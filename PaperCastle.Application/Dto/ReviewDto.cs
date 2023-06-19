using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCastle.Application.Dto
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public int BookId { get; set; }   
        public string UserName { get; set; }
    }
}
