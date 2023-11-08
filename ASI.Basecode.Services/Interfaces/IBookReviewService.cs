using ASI.Basecode.Services.Models;
using System.Collections.Generic;

namespace ASI.Basecode.WebApp.Services
{
    public interface IBookReviewService
    {
        List<BookReviewViewModel> GetAllBookReviews();
        BookReviewViewModel GetBookReviewById(int id);
        void AddBookReview(BookReviewViewModel model);
        void UpdateBookReview(BookReviewViewModel model);
        void DeleteBookReview(int id);
    }
}
