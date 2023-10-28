using ASI.Basecode.Services.Models;
using ASI.Basecode.WebApp.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASI.Basecode.WebApp.Controllers
{
    public class GenreController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGenreService _genreService;

        public GenreController(IMapper mapper, IGenreService genreService)
        {
            _mapper = mapper;
            _genreService = genreService;
        }

        public IActionResult Index()
        {
            var genreViewModels = _genreService.GetAllGenres();
            return View(genreViewModels);
        }

        public IActionResult Details(int id)
        {
            var viewModel = _genreService.GetGenreById(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GenreViewModel model)
        {
            if (ModelState.IsValid)
            {
                _genreService.AddGenre(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _genreService.GetGenreById(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(GenreViewModel model)
        {
            if (ModelState.IsValid)
            {
                _genreService.UpdateGenre(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _genreService.DeleteGenre(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
