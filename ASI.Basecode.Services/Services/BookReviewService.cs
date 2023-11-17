using ASI.Basecode.Services.Models;
using ASI.Basecode.WebApp.Services;
using AutoMapper;
using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ASI.Basecode.Services.Services
{
    public class BookReviewService : IBookReviewService
    {
        private readonly IBookReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public BookReviewService(IBookReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public List<BookReviewViewModel> GetAllBookReviews()
        {
            var reviews = _reviewRepository.GetAllBookReviews();
            return _mapper.Map<IEnumerable<BookReviewViewModel>>(reviews).ToList();
        }

        public List<BookReviewViewModel> GetBookReviewsByBook(Book book)
        {
            var reviews = _reviewRepository.GetBookReviewsByBook(book);
            return _mapper.Map<IEnumerable<BookReviewViewModel>>(reviews).ToList();
        }

        public BookReviewViewModel GetBookReviewById(int id)
        {
            var review = _reviewRepository.GetBookReviewById(id);
            return _mapper.Map<BookReviewViewModel>(review);
        }
        public List<BookReviewViewModel> GetBookReviewsByBookId(int bookId)
        {
            var reviews = _reviewRepository.GetBookReviewsByBookId(bookId); // Assumes this method exists
            return _mapper.Map<IEnumerable<BookReviewViewModel>>(reviews).ToList();
        }

        public void AddBookReview(BookReviewViewModel model)
        {
            if (!_reviewRepository.BookReviewExists(model.Id))
            {
                var review = _mapper.Map<BookReview>(model);

                _reviewRepository.AddBookReview(review);
            }
            else
            {
                throw new InvalidDataException(Resources.Messages.Errors.UserExists);
            }
        }


        public void UpdateBookReview(BookReviewViewModel model)
        {
            if (_reviewRepository.BookReviewExists(model.Id))
            {
                var existingBookReview = _reviewRepository.GetBookReviewById(model.Id);
                _mapper.Map(model, existingBookReview);

                _reviewRepository.UpdateBookReview(existingBookReview);
            }
        }

        public void DeleteBookReview(int id)
        {
            _reviewRepository.DeleteBookReview(id);
        }

    }
}
