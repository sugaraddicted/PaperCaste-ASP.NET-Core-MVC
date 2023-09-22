using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaperCastle.Core.Entity;
using PaperCastle.Application.Dto;
using PaperCastle.Infrastructure.Data.Repository;
using PaperCastle.Core;
using AutoMapper;
using PaperCastle.Infrastructure.Data.ViewModels;
using PaperCastle.Infrastructure.Data.Intefaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PaperCastle.WebUI.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository, IGenreRepository genreRepository, IAuthorRepository authorRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
            _authorRepository = authorRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

    public IActionResult Create()
    {
        SetViewBags();
        var newBookVM = new NewBookVM();
        return View(newBookVM);
    }

    [HttpPost]
        public async Task<IActionResult> Create(NewBookVM newBookVM)
        {
            if (!ModelState.IsValid)
            {
                return View(newBookVM);
            }

            //try
           // {
                var book = _mapper.Map<Book>(newBookVM);
                _bookRepository.CreateBook(book);
                return RedirectToAction(nameof(Index));
           // }
            //catch (Exception ex)
            //{
                //ModelState.AddModelError(string.Empty, "An error occurred while creating the book.");
               // SetViewBags();

                //return View(newBookVM);
            //}
        }
        public void SetViewBags()
        {
            var genres = _genreRepository.GetGenres();
            var authors = _authorRepository.GetAuthors();
            var countries = _countryRepository.GetCountries();

            var genreItems = genres.Select(genre => new SelectListItem
            {
                Text = genre.Name,
                Value = genre.Id.ToString()
            });

            var countryItems = countries.Select(country => new SelectListItem
            {
                Value = country.Id.ToString(),
                Text = country.Name
            }).ToList();

            var authorItems = authors.Select(author => new SelectListItem
            {
                Value = author.Id.ToString(),
                Text = author.Name
            }).ToList();

            ViewBag.Countries = new SelectList(countryItems, "Value", "Text");
            ViewBag.Authors = new SelectList(authorItems, "Value", "Text");
            ViewBag.Genres = new SelectList(genreItems, "Value", "Text");
        }
    }
}
