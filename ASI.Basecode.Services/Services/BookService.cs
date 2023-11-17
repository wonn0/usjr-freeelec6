using ASI.Basecode.Services.Models;
using ASI.Basecode.WebApp.Services;
using AutoMapper;
using Data.Interfaces;
using Data.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ASI.Basecode.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookService> _logger;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public List<BookViewModel> GetAllBooks()
        {
            var books = _bookRepository.GetAllBooks();
            return _mapper.Map<IEnumerable<BookViewModel>>(books).ToList();
        }

        public BookViewModel GetBookById(int id)
        {
            var book = _bookRepository.GetBookById(id);
            return _mapper.Map<BookViewModel>(book);
        }

        public List<BookViewModel> GetBooksByAuthor(int authorId)
        {
            // Query the repository for books by the author ID
            var books = _bookRepository.GetBookByAuthorId(authorId);


            // Select and project the data into the BookViewModel format
            var bookViewModels = books.Select(book => new BookViewModel
            {
                Id = book.Id,
                Name = book.Name,
                Description = book.Description,
                ISBN = book.ISBN,
                Language = book.Language,
                PublishedOn = book.PublishedOn,
                PageCount = book.PageCount,
                Created = book.Created,
                Updated = book.Updated,
                Image = book.Image,
                AuthorIds = book.AuthorBooks.Select(ab => ab.AuthorId).ToList(),
                GenreIds = book.BookGenres.Select(bg => bg.GenreId).ToList(),
                AuthorNames = book.AuthorBooks.Select(ab => ab.Author.FirstName + " " + ab.Author.LastName).ToList(),
                GenreNames = book.BookGenres.Select(bg => bg.Genre.Name).ToList()
            }).ToList();

            return bookViewModels;
        }


        public void AddBook(BookViewModel model)
        {
            if (!_bookRepository.BookExists(model.Id))
            {
                var book = _mapper.Map<Book>(model);
                book.Created = DateTime.Now;
                book.Updated = DateTime.Now;

                // Initialize AuthorBooks and BookGenres with empty collections if they are null
                if (model.AuthorIds == null) model.AuthorIds = new List<int>();
                if (model.GenreIds == null) model.GenreIds = new List<int>();

                // Handle adding of many authors and many genres
                book.AuthorBooks = model.AuthorIds.Select(authorId => new AuthorBook
                {
                    AuthorId = authorId,
                    Book = book
                }).ToList();

                book.BookGenres = model.GenreIds.Select(genreId => new BookGenre
                {
                    GenreId = genreId,
                    Book = book
                }).ToList();

                _bookRepository.AddBook(book);
            }
            else
            {
                throw new InvalidDataException(Resources.Messages.Errors.UserExists);
            }
        }


        public void UpdateBook(BookViewModel model)
        {
            if (_bookRepository.BookExists(model.Id))
            {
                var existingBook = _bookRepository.GetBookById(model.Id);
                _mapper.Map(model, existingBook);
                existingBook.AuthorBooks.Clear();
                existingBook.AuthorBooks = model.AuthorIds.Select(authorId => new AuthorBook
                {
                    AuthorId = authorId,
                    Book = existingBook
                }).ToList();

                existingBook.BookGenres.Clear();
                existingBook.BookGenres = model.GenreIds.Select(genreId => new BookGenre
                {
                    GenreId = genreId,
                    Book = existingBook
                }).ToList();
                _bookRepository.UpdateBook(existingBook);
            }
        }

        public void DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }
    }
}
