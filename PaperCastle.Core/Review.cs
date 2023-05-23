using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCastle.Core
{
    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Book Book { get; set; }
        public decimal Rating { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
