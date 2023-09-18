using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaperCastle.Core.Entity;
using PaperCastle.Application.Dto;
using PaperCastle.Infrastructure.Data.Repository;
using PaperCastle.Infrastructure.Data.Intefaces;
using PaperCastle.Infrastructure.Data.ViewModels;

namespace PaperCastle.WebUI.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public GenreController(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
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
        public async Task<IActionResult> Create(GenreDto genreDto)
        {
            if (ModelState.IsValid)
            {
                var genre = _mapper.Map<Genre>(genreDto);
                _genreRepository.CreateGenre(genre);
                return RedirectToAction(nameof(Index));
            }

            return View(genreDto);
        }
    }


}
