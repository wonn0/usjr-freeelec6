using ASI.Basecode.Services.Models;
using Data.Models;
using System.Collections.Generic;

namespace ASI.Basecode.WebApp.Services
{
    public interface IBookReviewService
    {
        List<BookReviewViewModel> GetAllBookReviews();
        BookReviewViewModel GetBookReviewById(int id);
        List<BookReviewViewModel> GetBookReviewsByBook(Book book);
        void AddBookReview(BookReviewViewModel model);
        void UpdateBookReview(BookReviewViewModel model);
        void DeleteBookReview(int id);
    }
}
