namespace PaperCastle.Core.Entity
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
