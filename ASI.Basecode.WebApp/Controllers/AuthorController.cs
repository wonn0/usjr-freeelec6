using ASI.Basecode.Services.Models;
using ASI.Basecode.WebApp.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASI.Basecode.WebApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAuthorService _authorService;

        public AuthorController(IMapper mapper, IAuthorService authorService)
        {
            _mapper = mapper;
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            var authorViewModels = _authorService.GetAllAuthors();
            return View(authorViewModels);
        }

        public IActionResult Details(int id)
        {
            var viewModel = _authorService.GetAuthorById(id);
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
        public IActionResult Create(AuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                _authorService.AddAuthor(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _authorService.GetAuthorById(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(AuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                _authorService.UpdateAuthor(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _authorService.DeleteAuthor(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
