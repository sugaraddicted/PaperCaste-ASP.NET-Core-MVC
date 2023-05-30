using PaperCastle.Core.Entity;
using PaperCastle.Infrastructure.Data.Intefaces;

namespace PaperCastle.Infrastructure.Data.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CountryExists(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }

        public ICollection<Book> GetBooksByCountry(int countryId)
        {
            return _context.Books.Where(a => a.Country.Id == countryId).ToList();
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountryById(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }
        public bool CreateCountry(Country country)
        {
            _context.Add(country);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCountry(Country country)
        {
            _context.Update(country);
            return Save();
        }

        public bool DeleteCountry(Country country)
        {
            _context.Remove(country);
            return Save();
        }
    }
}
