using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PaperCastle.Application.Dto;
using PaperCastle.Core.Entity;
using PaperCastle.Infrastructure.Data.Intefaces;
using PaperCastle.Infrastructure.Data.Repository;

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
        public async Task<IActionResult> Index()
        {
            var authors = await _authorRepository.GetAuthorsAsync();
            var authorDtos = _mapper.Map<ICollection<AuthorDto>>(authors);
            return View(authorDtos);
        }

        public async Task<IActionResult> Create()
        {
            var countries = await _countryRepository.GetCountriesAsync();

            var countryItems = countries.Select(country => new SelectListItem
            {
                Value = country.Id.ToString(),
                Text = country.Name
            }).ToList();
            ViewBag.Countries = new SelectList(countryItems, "Value", "Text");

            var authorDto = new AuthorDto();

            return View(authorDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorDto authorDto)
        {
            if (ModelState.IsValid)
            {
                var author = _mapper.Map<Author>(authorDto);
                await _authorRepository.CreateAsync(author);
                return RedirectToAction(nameof(Index));
            }

            return View(authorDto);
        }

        public async Task<IActionResult> Delete(int authorId)
        {
            var author = await _authorRepository.GetByIdAsync(authorId);

            await _authorRepository.DeleteAsync(author);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int authorId)
        {
            var author = await _authorRepository.GetByIdAsync(authorId);
            var authorDto = _mapper.Map<AuthorDto>(author);

            return View(authorDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            var countries = await _countryRepository.GetCountriesAsync();
            var countryItems = countries.Select(country => new SelectListItem
            {
                Value = country.Id.ToString(),
                Text = country.Name
            }).ToList();
            ViewBag.Countries = new SelectList(countryItems, "Value", "Text");

            var authorDto = _mapper.Map<AuthorDto>(author);
            return View(authorDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AuthorDto authorDto)
        {
            if (!ModelState.IsValid)
            {
                return View(authorDto);
            }

            var author = _mapper.Map<Author>(authorDto);
            await _authorRepository.UpdateAsync(id, author);

            return RedirectToAction(nameof(Index));
        }
    }
}
