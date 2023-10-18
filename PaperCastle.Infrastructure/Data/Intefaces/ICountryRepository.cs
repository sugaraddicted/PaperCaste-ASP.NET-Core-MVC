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
        Task<ICollection<Country>> GetCountriesAsync();
        Task<Country> GetByIdAsync(int id);
        Task<ICollection<Book>> GetBooksByCountryAsync(int countryId);
        bool CountryExists(int id);
        Task CreateAsync(Country country);
        Task UpdateAsync(int id, Country country);
        Task DeleteAsync(Country country);
        Task SaveAsync();
    }
}
