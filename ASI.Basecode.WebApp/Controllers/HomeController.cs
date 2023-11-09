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
        private readonly IBookReviewService _bookReviewService; // This should be the correct interface type

        public HomeController(IHttpContextAccessor httpContextAccessor, IBookService bookService,
                              ILoggerFactory loggerFactory,
                              IConfiguration configuration, IBookReviewService bookReviewService,
                              IMapper mapper = null)
            : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
            _bookReviewService = bookReviewService ?? throw new ArgumentNullException(nameof(bookReviewService));
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
        public IActionResult ViewBook(int id)
        {
            var viewModel = _bookService.GetBookById(id);
            if (viewModel is null)
            {
                _logger.LogWarning("Book with ID {BookId} not found.", id);
                return NotFound();
            }

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult ViewReview(int id)
        {
            var reviewsViewModel = _bookReviewService.GetReviewsByBookId(id);
            if (reviewsViewModel == null || !reviewsViewModel.Any())
            {
                // Handle the case where there are no reviews
                return View("NoReviews"); // You should create a view called NoReviews.cshtml
            }
            return View(reviewsViewModel);
        }


    }
}
