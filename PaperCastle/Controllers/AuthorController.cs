using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PaperCastle.Application.Dto;
using PaperCastle.Core.Entity;
using PaperCastle.Infrastructure.Data.Intefaces;

namespace PaperCastle.WebUI.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorRepository authorRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var countries = _countryRepository.GetCountries();

            var countryItems = countries.Select(country => new SelectListItem
            {
                Value = country.Id.ToString(),
                Text = country.Name
            }).ToList();

            var authorDto = new AuthorDto();

            ViewBag.Countries = new SelectList(countryItems, "Value", "Text");

            return View(authorDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorDto authorDto)
        {
            if (ModelState.IsValid)
            {
                var author = _mapper.Map<Author>(authorDto);
                _authorRepository.CreateAuthor(author);
                return RedirectToAction(nameof(Index));
            }

            return View(authorDto);
        }
    }
}
