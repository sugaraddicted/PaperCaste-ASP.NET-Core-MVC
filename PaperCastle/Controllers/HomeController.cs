using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaperCastle.Application.Dto;
using PaperCastle.Infrastructure.Data.Intefaces;
using PaperCastle.Models;
using System.Diagnostics;

namespace PaperCastle.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IBookRepository bookRepository, IMapper mapper)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookRepository.GetBooksAsync();
            var bookDtos = _mapper.Map<List<BookDto>>(books);
            return View(bookDtos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}