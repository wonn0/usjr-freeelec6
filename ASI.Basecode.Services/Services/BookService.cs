using ASI.Basecode.Services.Models;
using AutoMapper;
using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using ASI.Basecode.WebApp.Services;
using System.IO;

namespace ASI.Basecode.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public IEnumerable<BookViewModel> GetAllBooks()
        {
            var books = _bookRepository.GetAllBooks();
            return _mapper.Map<IEnumerable<BookViewModel>>(books);
        }

        public BookViewModel GetBookById(int id)
        {
            var book = _bookRepository.GetBookById(id);
            return _mapper.Map<BookViewModel>(book);
        }

        public void AddBook(BookViewModel model)
        {
            if (!_bookRepository.BookExists(model.Id))
            {
                var book = _mapper.Map<Book>(model);
                book.Created = DateTime.Now;
                book.Updated = DateTime.Now;
                _bookRepository.AddBook(book);
            }
            else
            {
                throw new InvalidDataException(Resources.Messages.Errors.UserExists);
            }
        }

        public void UpdateBook(BookViewModel model)
        {
            var existingBook = _bookRepository.GetBookById(model.Id);

            if (existingBook != null)
            {
                _mapper.Map(model, existingBook);
                _bookRepository.UpdateBook(existingBook);
            }
        }

        public void DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }
    }
}
