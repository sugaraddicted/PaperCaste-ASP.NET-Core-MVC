using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCastle.Application.Dto
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PictureURL { get; set; }
        public string Bio { get; set; }
        public int? CountryId { get; set; }
    }
}
