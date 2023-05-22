using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCastle.Core
{
    public class Country
    {
        public int Id {  get; set; }
        public string Name { get; set; }    
        public ICollection<Book> Books { get; set; }
    }
}
