using ASI.Basecode.WebApp.Models;
using AutoMapper;
using Data.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ASI.Basecode.WebApp.Controllers
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BookController"/> class.
    /// </summary>
    /// <param name="signInManager">The sign in manager.</param>
    /// <param name="localizer">The localizer.</param>
    /// <param name="userService">The user service.</param>
    /// <param name="httpContextAccessor">The HTTP context accessor.</param>
    /// <param name="loggerFactory">The logger factory.</param>
    /// <param name="configuration">The configuration.</param>
    /// <param name="mapper">The mapper.</param>
    /// <param name="tokenValidationParametersFactory">The token validation parameters factory.</param>
    /// <param name="tokenProviderOptionsFactory">The token provider options factory.</param>
    public class BookController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public BookController(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            var books = _bookRepository.GetAllBooks().ToList();
            var bookViewModels = _mapper.Map<IEnumerable<BookViewModel>>(books);
            return View(bookViewModels);
        }

        public IActionResult Details(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<BookViewModel>(book);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = _mapper.Map<Book>(model);
                _bookRepository.AddBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            var bookViewModel = _mapper.Map<BookViewModel>(book);
            return View(bookViewModel);
        }


        [HttpPost]
        public IActionResult Edit(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = _mapper.Map<Book>(model);
                _bookRepository.UpdateBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _bookRepository.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
