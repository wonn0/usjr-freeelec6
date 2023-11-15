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
    public class BookReviewCommentService : IBookReviewCommentService
    {
        private readonly IBookReviewCommentRepository _commentRepository;
        private readonly IBookReviewRepository _bookReviewRepository;
        private readonly IMapper _mapper;

        public BookReviewCommentService(IBookReviewCommentRepository commentRepository, IBookReviewRepository bookReviewRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _bookReviewRepository = bookReviewRepository;
            _mapper = mapper;
        }

        public List<BookReviewCommentViewModel> GetAllBookReviewComments()
        {
            var comments = _commentRepository.GetAllBookReviewComments();
            return _mapper.Map<IEnumerable<BookReviewCommentViewModel>>(comments).ToList();
        }


        public BookReviewCommentViewModel GetBookReviewCommentById(int id)
        {
            var comment = _commentRepository.GetBookReviewCommentById(id);
            return _mapper.Map<BookReviewCommentViewModel>(comment);
        }

        public List<BookReviewCommentViewModel> GetBookReviewCommentsByReview(BookReviewViewModel review)
        {
            var reviewToData = _mapper.Map<BookReview>(review);
            var comments = _commentRepository.GetBookReviewCommentsByReview(reviewToData);
            return _mapper.Map<IEnumerable<BookReviewCommentViewModel>>(comments).ToList();
        }

        public void AddBookReviewComment(BookReviewCommentViewModel model)
        {
            if (!_commentRepository.BookReviewCommentExists(model.Id))
            {
                var comment = _mapper.Map<BookReviewComment>(model);

                _commentRepository.AddBookReviewComment(comment);
            }
            else
            {
                throw new InvalidDataException(Resources.Messages.Errors.UserExists);
            }
        }


        public void UpdateBookReviewComment(BookReviewCommentViewModel model)
        {
            if (_commentRepository.BookReviewCommentExists(model.Id))
            {
                var existingBookReviewComment = _commentRepository.GetBookReviewCommentById(model.Id);
                _mapper.Map(model, existingBookReviewComment);

                _commentRepository.UpdateBookReviewComment(existingBookReviewComment);
            }
        }

        public void DeleteBookReviewComment(int id)
        {
            _commentRepository.DeleteBookReviewComment(id);
        }
    }
}
