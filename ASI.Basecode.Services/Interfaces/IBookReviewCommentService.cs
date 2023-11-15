using ASI.Basecode.Services.Models;
using Data.Models;
using System.Collections.Generic;

namespace ASI.Basecode.WebApp.Services
{
    public interface IBookReviewCommentService
    {
        List<BookReviewCommentViewModel> GetAllBookReviewComments();
        BookReviewCommentViewModel GetBookReviewCommentById(int id);
        List<BookReviewCommentViewModel> GetBookReviewCommentsByReview(BookReviewViewModel review);
        void AddBookReviewComment(BookReviewCommentViewModel model);
        void UpdateBookReviewComment(BookReviewCommentViewModel model);
        void DeleteBookReviewComment(int id);
    }
}
