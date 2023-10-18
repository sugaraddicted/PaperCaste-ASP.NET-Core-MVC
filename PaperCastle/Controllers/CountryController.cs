using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaperCastle.Application.Dto;
using PaperCastle.Core.Entity;
using PaperCastle.Infrastructure.Data.Intefaces;
using PaperCastle.Infrastructure.Data.Repository;

namespace PaperCastle.WebUI.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController( ICountryRepository countryRepository, IMapper mapper)
        {
             _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var countries = await _countryRepository.GetCountriesAsync();
            var countriesDto = _mapper.Map<ICollection<CountryDto>>(countries);
            return View(countriesDto);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CountryDto countryDto) 
        {
            if (ModelState.IsValid)
            {
                var country = _mapper.Map<Country>(countryDto);
                await _countryRepository.CreateAsync(country);
                return RedirectToAction(nameof(Index));
            }

            return View(countryDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var country = await _countryRepository.GetByIdAsync(id);
            var countryDto = _mapper.Map<CountryDto>(country);
            if (countryDto == null) return View("NotFound");

            return View(countryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Name")] CountryDto countryDto)
        {
            if (!ModelState.IsValid)
            {
                return View(countryDto);
            }

            var country = _mapper.Map<Country>(countryDto);
            await _countryRepository.UpdateAsync(id, country);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int countryId)
        {
            var country = await _countryRepository.GetByIdAsync(countryId); 
            if(country == null)
            {
                return View("Error");
            }
            await _countryRepository.DeleteAsync(country);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            var country = await _countryRepository.GetByIdAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            var countryDto = _mapper.Map<CountryDto>(country);

            return View(countryDto);
        }
    }
}
