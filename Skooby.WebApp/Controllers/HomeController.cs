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



namespace Skooby.WebApp.Controllers
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
        [HttpGet]
        public ActionResult BookReview(int id) // assuming id is the book's ID
        {
            var book = _bookService.GetBookById(id);// You would need to fetch the book by id here, possibly using another service
            var reviews = _bookReviewService.GetBookReviewsByBookId(id);
            return View(reviews);

        }

        [HttpGet]
        // public IActionResult Index()
        // {
        //     var bookViewModels = _bookService.GetAllBooks()!;
        //     return View(bookViewModels);
        // }
        [HttpGet]
        public IActionResult Index(string searchTerm)
        {
            var allBooks = _bookService.GetAllBooks(); // Replace with your method to get all books
            IEnumerable<BookViewModel> model;

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                model = allBooks.Where(book => book.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                model = allBooks;
            }

            return View(model);
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
                var authorIds = bookViewModel.AuthorIds;

                foreach (var authorId in authorIds)
                {
                    var booksForAuthor = _bookService.GetAllBooks()
                        .Where(book => book.AuthorIds.Contains(authorId) && book.Id != id)
                        .ToList();

                    relatedBooks.AddRange(booksForAuthor);
                }
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


        public IActionResult Loading()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewBooks(int pageNo)
        {
            var pageSize = 10; // Adjust based on your requirements
            var allBooks = _bookService.GetAllBooks();

            // Calculate total pages
            var totalBooksCount = allBooks.Count;
            var totalPages = totalBooksCount / pageSize;

            if (totalBooksCount % pageSize > 0)
            {
                totalPages += 1;
            }
            // Use the service method to get paginated books
            var recentBooks = _bookService.GetNewestBooksPaginated(pageNo, pageSize);

            ViewBag.CurrentPage = pageNo;
            ViewBag.TotalPages = totalPages;

            return View(recentBooks);
        }






        [HttpGet]
        public IActionResult TopRatedBooks(int pageNo)
        {
            var pageSize = 10;
            // Assuming GetAllBooks returns a collection of all books
            var allBooks = _bookService.GetAllBooks();

            // Calculate total pages
            var totalBooksCount = allBooks.Count;
            var totalPages = totalBooksCount / pageSize;

            if (totalBooksCount % pageSize > 0)
            {
                totalPages += 1;
            }



            var booksWithReviews = allBooks
                .GroupJoin(
                    _bookReviewService.GetAllBookReviews(),
                    book => book.Id,
                    review => review.BookId,
                    (book, reviews) => new
                    {
                        Book = book,
                        AverageRating = reviews.Any() ? reviews.Average(review => review.Rating) : 0
                    })
                .OrderByDescending(result => result.AverageRating)
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .Select(result => result.Book)
                .ToList();

            ViewBag.CurrentPage = pageNo; 
            ViewBag.TotalPages =totalPages;
           
            return View(booksWithReviews);
        }
 


        [HttpGet]
        public IActionResult GenreSeeMore(string genre, int pageNo = 1)
        {
            var pageSize = 10;

            
            var allBooks = _bookService.GetAllBooks();

           
            var booksInGenre = allBooks.Where(book => book.GenreNames.Any(genreName => string.Equals(genreName, genre, StringComparison.OrdinalIgnoreCase)));


            var model = booksInGenre
    .Skip((pageNo - 1) * pageSize)
    .Take(pageSize)
    .ToList();



            var totalBooksCount = booksInGenre.Count();
            var totalPages = (int)Math.Ceiling((double)totalBooksCount / pageSize);

            // Set ViewBag data for pagination in the view
            ViewBag.CurrentPage = pageNo;
            ViewBag.TotalPages = totalPages;
                 ViewBag.Genre = genre;


            return View(model);
        }

        [HttpGet]
        public IActionResult AuthorRelatedWorks(string author, int pageNo = 1)
        {
            var pageSize = 10;

            // Assuming GetAllBooks returns a collection of all books
            var allBooks = _bookService.GetAllBooks();

            // Filter books by author
            var booksByAuthor = allBooks.Where(book => book.AuthorNames.Any(authorName => string.Equals(authorName, author, StringComparison.OrdinalIgnoreCase)));

            // Paginate the results
            var model = booksByAuthor
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Calculate total pages
            var totalBooksCount = booksByAuthor.Count();
            var totalPages = (int)Math.Ceiling((double)totalBooksCount / pageSize);

            // Set ViewBag data for pagination in the view
            ViewBag.CurrentPage = pageNo;
            ViewBag.TotalPages = totalPages;
            ViewBag.Author = author;

            return View(model);
        }

        [HttpGet]
        public IActionResult SuggestedForU(int pageNo = 1)
        {
            var pageSize = 10;

            // Assuming GetAllBooks returns a collection of all books
            var allBooks = _bookService.GetAllBooks();

            // Randomize the order of all books
            var random = new Random();
            var randomizedBooks = allBooks.OrderBy(book => random.Next());

            // Paginate the results
            var model = randomizedBooks
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Calculate total pages
            var totalBooksCount = allBooks.Count();
            var totalPages = (int)Math.Ceiling((double)totalBooksCount / pageSize);

            // Set ViewBag data for pagination in the view
            ViewBag.CurrentPage = pageNo;
            ViewBag.TotalPages = totalPages;

            return View(model);
        }


        [HttpGet]
        public IActionResult GenreSeeMore(string genre, int pageNo = 1)
        {
            var pageSize = 10;


            var allBooks = _bookService.GetAllBooks();


            var booksInGenre = allBooks.Where(book => book.GenreNames.Any(genreName => string.Equals(genreName, genre, StringComparison.OrdinalIgnoreCase)));


            var model = booksInGenre
    .Skip((pageNo - 1) * pageSize)
    .Take(pageSize)
    .ToList();



            var totalBooksCount = booksInGenre.Count();
            var totalPages = (int)Math.Ceiling((double)totalBooksCount / pageSize);

            // Set ViewBag data for pagination in the view
            ViewBag.CurrentPage = pageNo;
            ViewBag.TotalPages = totalPages;
            ViewBag.Genre = genre;


            return View(model);
        }

        [HttpGet]
        public IActionResult AuthorRelatedWorks(List<string> authors, int id, int pageNo = 1)
        {
            var pageSize = 10;

            // Assuming GetAllBooks returns a collection of all books
            var allBooks = _bookService.GetAllBooks();

            // Filter books by authors
            var booksByAuthors = allBooks.Where(book => book.AuthorNames.Any(authorName => authors.Contains(authorName, StringComparer.OrdinalIgnoreCase) && book.Id != id));

            // Paginate the results
            var model = booksByAuthors
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Calculate total pages
            var totalBooksCount = booksByAuthors.Count();
            var totalPages = (int)Math.Ceiling((double)totalBooksCount / pageSize);

            // Set ViewBag data for pagination in the view
            ViewBag.CurrentPage = pageNo;
            ViewBag.TotalPages = totalPages;
            ViewBag.Authors = authors;

            return View(model);
        }



        [HttpGet]
        public IActionResult SuggestedForU(int pageNo = 1)
        {
            var pageSize = 10;

            // Assuming GetAllBooks returns a collection of all books
            var allBooks = _bookService.GetAllBooks();

            // Randomize the order of all books
            var random = new Random();
            var randomizedBooks = allBooks.OrderBy(book => random.Next());

            // Paginate the results
            var model = randomizedBooks
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Calculate total pages
            var totalBooksCount = allBooks.Count();
            var totalPages = (int)Math.Ceiling((double)totalBooksCount / pageSize);

            // Set ViewBag data for pagination in the view
            ViewBag.CurrentPage = pageNo;
            ViewBag.TotalPages = totalPages;

            return View(model);
        }


        [HttpPost]
        public IActionResult AddReview([FromBody] BookReviewViewModel reviewModel)
        {
            try
            {
                // You might need to set the BookId and other missing fields here
                _bookReviewService.AddBookReview(reviewModel);
                return Json(new { success = true, message = "Review added successfully." });
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Error adding review");
                return Json(new { success = false, message = "Error adding review." });
            }
        }

    }
}
