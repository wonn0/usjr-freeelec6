using ASI.Basecode.Services.Models;
using ASI.Basecode.WebApp.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Add this to use ILogger

namespace ASI.Basecode.WebApp.Controllers
{
    public class GenreController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGenreService _genreService;
        private readonly ILogger<GenreController> _logger; // Declare the logger

        // Inject the ILogger into the constructor
        public GenreController(IMapper mapper, IGenreService genreService, ILogger<GenreController> logger)
        {
            _mapper = mapper;
            _genreService = genreService;
            _logger = logger; // Initialize the logger
        }

        public IActionResult Index()
        {
            var genreViewModels = _genreService.GetAllGenres();
            _logger.LogInformation("Loaded all genres"); // Example log
            return View(genreViewModels);
        }

        public IActionResult Details(int id)
        {
            var viewModel = _genreService.GetGenreById(id);
            if (viewModel == null)
            {
                _logger.LogWarning("Genre with ID {GenreId} not found.", id); // Log warning
                return NotFound();
            }
            _logger.LogInformation("Loaded genre details for ID {GenreId}", id); // Example log
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
                _logger.LogInformation("Genre created: {GenreName}", model.Name); // Log information
                return RedirectToAction(nameof(Index));
            }
            _logger.LogWarning("Invalid model state for creating genre."); // Log warning
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _genreService.GetGenreById(id);
            if (viewModel == null)
            {
                _logger.LogWarning("Edit attempted for non-existent genre with ID {GenreId}.", id); // Log warning
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
                _logger.LogInformation("Genre updated: {GenreId}", model.Id); // Log information
                return RedirectToAction(nameof(Index));
            }
            _logger.LogWarning("Invalid model state for editing genre with ID {GenreId}.", model.Id); // Log warning
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _genreService.DeleteGenre(id);
            _logger.LogInformation("Genre deleted: {GenreId}", id); // Log information
            return RedirectToAction(nameof(Index));
        }
    }
}
