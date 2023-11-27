#nullable enable
using ASI.Basecode.Services.Models;
using ASI.Basecode.WebApp.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASI.Basecode.WebApp.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBookReviewService _bookReviewService;
        private readonly ILogger<ReviewsController> _logger;

        public ReviewsController(IMapper mapper, IBookReviewService bookReviewService, ILogger<ReviewsController> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _bookReviewService = bookReviewService ?? throw new ArgumentNullException(nameof(bookReviewService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public IActionResult Index(string? searchString)
        {
            var reviewViewModels = _bookReviewService.GetAllBookReviews();

            if (!String.IsNullOrEmpty(searchString))
            {
                reviewViewModels = reviewViewModels.Where(r =>
                    (r.ReviewedBy != null && r.ReviewedBy.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                    (r.BookName != null && r.BookName.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                    (r.Description != null && r.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                ).ToList();
            }

            return View(reviewViewModels);
        }


        public IActionResult Details(int id)
        {
            var viewModel = _bookReviewService.GetBookReviewById(id);
            if (viewModel is null)
            {
                _logger.LogWarning("Review with ID {ReviewId} not found.", id);
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
        public IActionResult Create(BookReviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                _bookReviewService.AddBookReview(model);
                _logger.LogInformation("Review created for book ID {BookId}", model.BookId);
                foreach (var state in ModelState)
                {
                    if (state.Value.Errors.Any())
                    {
                        _logger.LogWarning("Validation error in field {FieldName}: {ErrorMessage}", state.Key, state.Value.Errors.First().ErrorMessage);
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            _logger.LogWarning("Invalid model state for creating review.");
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _bookReviewService.GetBookReviewById(id);
            if (viewModel is null)
            {
                _logger.LogWarning("Edit attempted for non-existent review with ID {ReviewId}.", id);
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(BookReviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                _bookReviewService.UpdateBookReview(model);
                _logger.LogInformation("Review updated: {ReviewId}", model.Id);
                return RedirectToAction(nameof(Index));
            }
            _logger.LogWarning("Invalid model state for editing review with ID {ReviewId}.", model.Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _bookReviewService.DeleteBookReview(id);
            _logger.LogInformation("Review deleted: {ReviewId}", id);
            return RedirectToAction(nameof(Index));
        }
    }
}
