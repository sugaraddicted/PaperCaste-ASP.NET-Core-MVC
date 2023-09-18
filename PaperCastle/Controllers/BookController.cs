using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaperCastle.Core.Entity;
using PaperCastle.Application.Dto;
using PaperCastle.Infrastructure.Data.Repository;
using PaperCastle.Core;
using AutoMapper;
using PaperCastle.Infrastructure.Data.ViewModels;
using PaperCastle.Infrastructure.Data.Intefaces;

namespace PaperCastle.WebUI.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewBookVM newBookVM)
        {
            if (ModelState.IsValid)
            {
                var book = _mapper.Map<Book>(newBookVM);
                _bookRepository.CreateBook(book);
                return RedirectToAction(nameof(Index));
            }

            return View(newBookVM);
        }
    }
}
