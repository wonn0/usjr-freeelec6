﻿using ASI.Basecode.WebApp.Mvc;
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
        public IActionResult ViewBook(int bookId)
        {
            // Fetch the book and reviews from the database or service layer
            // For example:
            BookViewModel book = _bookService.GetBookById(bookId);
            List<BookReviewViewModel> reviews = _bookReviewService.GetBookReviewsByBookId(bookId);

            // Create and populate the BookDetailsViewModel
            BookDetailsViewModel model = new BookDetailsViewModel
            {
                Book = book,
                Reviews = reviews
            };

            // Pass the BookDetailsViewModel to the view
            return View(model);
        }
        // ... other actions
    }
}
