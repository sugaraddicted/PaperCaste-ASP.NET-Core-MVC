using PaperCastle.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PaperCastle.Infrastructure.Data.Intefaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountryById(int id);

        ICollection<Book> GetBooksByCountry(int countryId);

        bool CountryExists(int id);

        bool CreateCountry(Country country);

        bool UpdateCountry(Country country);

        bool DeleteCountry(Country country);

        bool Save();
    }
}
