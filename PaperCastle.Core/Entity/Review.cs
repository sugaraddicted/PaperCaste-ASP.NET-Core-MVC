using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCastle.Core.Entity
{
    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int BookId { get; set; } 
        public Book Book { get; set; }
        public int Rating { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
