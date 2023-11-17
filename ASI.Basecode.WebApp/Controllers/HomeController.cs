using ASI.Basecode.WebApp.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ASI.Basecode.Services.Models;
using ASI.Basecode.WebApp.Services;
using Microsoft.Extensions.Logging;
#nullable enable // This enables nullable reference types for this file
using System;
using System.Collections.Generic;
using System.Linq;



namespace ASI.Basecode.WebApp.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    public class HomeController : ControllerBase<HomeController>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="configuration"></param>
        /// <param name="localizer"></param>
        /// <param name="mapper"></param>
        private readonly IBookService _bookService;
        private readonly IBookReviewService _bookReviewService;

        public HomeController(IHttpContextAccessor httpContextAccessor, IBookService bookService,
                              ILoggerFactory loggerFactory,
                              IConfiguration configuration, IBookReviewService bookReviewService,
                              IMapper mapper = null)
            : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
            _bookReviewService = bookReviewService;
            // Assuming _logger is initialized in the base class.
        }

        /// <summary>
        /// Returns Home View.
        /// </summary>
        /// <returns> Home View </returns>
        public IActionResult Index()
        {
            // Use _logger to log the information
            _logger.LogInformation("Home page visited at {Time}", System.DateTime.Now);

            return View();
        }
        [HttpGet]
        public ActionResult BookReview(int id) // assuming id is the book's ID
        {
            var book = _bookService.GetBookById(id);// You would need to fetch the book by id here, possibly using another service
            var reviews = _bookReviewService.GetBookReviewsByBookId(id);
            return View(reviews);

        }

        [HttpGet]
        public IActionResult ViewBook(int id)
        {
            // Fetch the book from the database or service layer
            var bookViewModel = _bookService.GetBookById(id); // Assuming GetBookById returns a BookViewModel
            if (bookViewModel == null)
            {
                // Log the error before redirecting or returning an error view
                _logger.LogError("Book with ID {BookId} not found.", id);

                // Redirect to a custom error page
                return RedirectToAction("Error", new { message = "Book not found" });
            }

            // Fetch the related books by author. This assumes that the BookViewModel has AuthorIds.
            List<BookViewModel> relatedBooks = new List<BookViewModel>();
            if (bookViewModel.AuthorIds != null && bookViewModel.AuthorIds.Any())
            {
                int authorId = bookViewModel.AuthorIds.First(); // Take the first author's ID
                relatedBooks = _bookService.GetBooksByAuthor(authorId); // Assuming GetBooksByAuthor returns List<BookViewModel>
            }
            else
            {
                // Log the error if there are no author IDs
                _logger.LogError("No authors found for book ID {BookId}.", id);
            }

            // Log the book name
            _logger.LogInformation("Book name: {BookName}", bookViewModel.Name);

            // If book is not null, fetch the reviews
            var reviews = _bookReviewService.GetBookReviewsByBookId(id);

            // Check if there's at least one review to avoid index out of range exception
            if (reviews.Count > 1)
            {
                // Log the second review's ReviewedBy
                _logger.LogInformation("Second review's ReviewedBy: {ReviewedBy}", reviews[1].ReviewedBy);
            }
            else
            {
                // Log if there are less than two reviews
                _logger.LogInformation("There are less than two reviews.");
            }

            // Create and populate the BookDetailsViewModel
            BookDetailsViewModel model = new BookDetailsViewModel
            {
                Book = bookViewModel,
                Reviews = reviews,
                RelatedBooks = relatedBooks.ToArray(),
                AllBooks = _bookService.GetAllBooks()// Convert the list to an array
            };

            // Pass the BookDetailsViewModel to the view
            return View(model);
        }




        // ... other actions
    }
}
