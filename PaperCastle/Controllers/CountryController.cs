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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CountryDto countryDto) 
        {
            if (ModelState.IsValid)
            {
                var country = _mapper.Map<Country>(countryDto);
                _countryRepository.CreateCountry(country);
                return RedirectToAction(nameof(Index));
            }

            return View(countryDto);
        }
    }
}
