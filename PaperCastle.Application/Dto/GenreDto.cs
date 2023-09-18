using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCastle.Application.Dto
{
    public class GenreDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Genre name is required")]
        [MaxLength(50, ErrorMessage = "Genre name cannot exceed 50 characters")]
        public string Name { get; set; }

        [MaxLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
        public string Description { get; set; }
    }
}
