using System;
using System.Collections.Generic;
using System.Linq;
using ASI.Basecode.Services.Models;
using ASI.Basecode.WebApp.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Add logging namespace

namespace ASI.Basecode.WebApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAuthorService _authorService;
        private readonly ILogger<AuthorController> _logger; // Logging field

        public AuthorController(IMapper mapper, IAuthorService authorService, ILogger<AuthorController> logger) // Add logger parameter
        {
            _mapper = mapper;
            _authorService = authorService;
            _logger = logger; // Set the logger
        }

        public IActionResult Index(string searchQuery, int pageNo = 1 )
        {
            var pageSize = 10;
            IEnumerable<AuthorViewModel> authors;

            if (!string.IsNullOrEmpty(searchQuery))
            {
                // Assuming _authorService has a method to search authors by a query
                authors = _authorService.SearchAuthors(searchQuery);
            }
            else
            {
                authors = _authorService.GetAllAuthors();
            }

            var totalAuthors = authors.Count();
            var model = authors.Skip((pageNo - 1) * pageSize)
          .Take(pageSize)
          .ToList();

            int totalPages = (int)Math.Ceiling((double)totalAuthors / pageSize);
            ViewBag.CurrentPage = pageNo;
            ViewBag.TotalPages = totalPages;

            return View(model);

        }


        public IActionResult Details(int id)
        {
            var viewModel = _authorService.GetAuthorById(id);
            if (viewModel == null)
            {
                _logger.LogWarning("Author with ID {AuthorId} not found.", id); // Log warning
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
                _logger.LogInformation("Author created: {AuthorName} {LastName}", model.FirstName, model.LastName); // Log information
                return RedirectToAction(nameof(Index));
            }
            _logger.LogWarning("Invalid model state for creating author."); // Log warning
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _authorService.GetAuthorById(id);
            if (viewModel == null)
            {
                _logger.LogWarning("Edit attempted for non-existent author with ID {AuthorId}.", id); // Log warning
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
                _logger.LogInformation("Author updated: {AuthorId}", model.Id); // Log information
                return RedirectToAction(nameof(Index));
            }
            _logger.LogWarning("Invalid model state for editing author with ID {AuthorId}.", model.Id); // Log warning
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _authorService.DeleteAuthor(id);
            _logger.LogInformation("Author deleted: {AuthorId}", id); // Log information
            return RedirectToAction(nameof(Index));
        }
    }
}
