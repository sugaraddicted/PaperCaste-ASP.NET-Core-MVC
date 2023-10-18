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

        public async Task<IActionResult> Index() {

            var books = await _bookRepository.GetBooksAsync();
            var bookDtos = _mapper.Map<ICollection<BookDto>>(books);
            return View(bookDtos);
        }

        [Route("Book/Create")]
        public async Task<IActionResult> Create()
        {
            await SetViewBags();
            var newBookVM = new BookVM();
            return View(newBookVM);
        }

        [Route("Book/Create")]
        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> Create(BookVM newBookVM)
        {
            if (!ModelState.IsValid)
            {
                return View(newBookVM);
            }

            try
            {
                var book = _mapper.Map<Book>(newBookVM);
                await _bookRepository.CreateAsync(book);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the book.");
                SetViewBags();

                return View(newBookVM);
            }
        }

        [Route("Book/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            await SetViewBags();
            var book = await _bookRepository.GetByIdAsync(id);
            var BookVM = _mapper.Map<BookVM>(book);
            return View(BookVM);
        }

        [Route("Book/Edit/{id}")]
        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Edit(int id, BookVM bookVM)
        {
            if (!ModelState.IsValid)
            {
                await SetViewBags();
                return View(bookVM);
            }

            try
            {
                var book = _mapper.Map<Book>(bookVM);
                await _bookRepository.UpdateAsync(id, book);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while editing the book.");
                await SetViewBags();

                return View(bookVM);
            }
        }

        [Route("Book/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            var bookDto = _mapper.Map<BookDto>(book);

            return View(bookDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            await _bookRepository.DeleteAsync(book);
            return RedirectToAction(nameof(Index));
        }

        public async Task SetViewBags()
        {
            var genres = await _genreRepository.GetGenresAsync();
            var authors = await _authorRepository.GetAuthorsAsync();
            var countries = await _countryRepository.GetCountriesAsync();

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
