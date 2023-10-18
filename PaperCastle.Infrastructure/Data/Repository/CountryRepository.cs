using Microsoft.EntityFrameworkCore;
using PaperCastle.Core.Entity;
using PaperCastle.Infrastructure.Data.Intefaces;
using System;

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

        public async Task<ICollection<Book>> GetBooksByCountryAsync(int countryId)
        {
            return await _context.Books
                .Where(a => a.Country.Id == countryId)
                .ToListAsync();
        }

        public async Task<ICollection<Country>> GetCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            return _context.Countries
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public async Task CreateAsync(Country country)
        {
            _context.Add(country);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Country country)
        {
            var existingCountry = await GetByIdAsync(id);

            if (existingCountry == null)
            {
                throw new Exception("Genre not found");
            }

            existingCountry.Name = country.Name;

            _context.Update(existingCountry);

            await SaveAsync();
        }

        public async Task DeleteAsync(Country country)
        {
            _context.Remove(country);
            await SaveAsync();
        }
    }
}