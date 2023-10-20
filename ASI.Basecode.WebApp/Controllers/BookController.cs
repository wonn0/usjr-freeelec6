using ASI.Basecode.WebApp.Models;
using AutoMapper;
using Data.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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
        private readonly IAuthorRepository _authorRepository;

        public BookController(IMapper mapper, IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
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

        [HttpGet]
        public IActionResult Create()
        {
            var authors = _authorRepository.GetAllAuthors()
                                   .Select(a => new
                                   {
                                       Id = a.Id,
                                       FullName = a.FirstName + " " + a.LastName
                                   })
                                   .ToList();
            ViewBag.AuthorList = new SelectList(authors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = _mapper.Map<Book>(model);
                book.Created = DateTime.Now;
                book.Updated = DateTime.Now;
                _bookRepository.AddBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id, BookViewModel model)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            var authors = _authorRepository.GetAllAuthors()
                                   .Select(a => new
                                   {
                                       Id = a.Id,
                                       FullName = a.FirstName + " " + a.LastName
                                   })
                                   .ToList();
            var bookViewModel = _mapper.Map<BookViewModel>(book);
            ViewBag.AuthorList = new SelectList(authors, "Id", "FullName");
            return View(bookViewModel);
        }


        [HttpPost]
        public IActionResult Edit(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingBook = _bookRepository.GetBookById(model.Id);

                if (existingBook == null)
                {
                    return NotFound();
                }

                _mapper.Map(model, existingBook);
                _bookRepository.UpdateBook(existingBook);

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
