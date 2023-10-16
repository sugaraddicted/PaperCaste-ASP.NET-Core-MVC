using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaperCastle.Core.Entity;
using PaperCastle.Application.Dto;
using PaperCastle.Infrastructure.Data.Intefaces;

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

        public async Task<IActionResult> Index()
        {
            var genres = await _genreRepository.GetGenresAsync();
            var genreDtos = _mapper.Map<ICollection<GenreDto>>(genres);
            return View(genreDtos);
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
                await _genreRepository.CreateAsync(genre);

                return RedirectToAction(nameof(Index));
            }

            return View(genreDto);
        }

        public async Task<IActionResult> Delete(int genreId)
        {
            var genre = await _genreRepository.GetByIdAsync(genreId);

            if(genre != null)
                await _genreRepository.DeleteAsync(genre);

            return RedirectToAction(nameof(Index));
        }
    }
}
