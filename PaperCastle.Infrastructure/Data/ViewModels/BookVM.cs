using System.ComponentModel.DataAnnotations;

namespace PaperCastle.Infrastructure.Data.ViewModels
{
    public class BookVM
    {
        public int Id { get; set; }

        [Display(Name = "Book title")]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Display(Name = "Book description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Book cover URL")]
        [Required(ErrorMessage = "Book cover URL is required")]
        public string CoverImageURL { get; set; }

        [Display(Name = "Year of writting")]
        public int YearOfWriting { get; set; }

        //Relationships
        [Display(Name = "Select genre(s)")]
        [Required(ErrorMessage = "Book genre(s) is required")]
        public List<int> GenreIds { get; set; }

        [Display(Name = "Select an author")]
        public int AuthorId { get; set; }

        [Display(Name = "Select a country")]
        public int CountryId { get; set; }
    }
}
