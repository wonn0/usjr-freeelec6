using Data.Models;
using System.Linq;

namespace Data.Interfaces
{
    public interface IBookReviewRepository
    {
        IQueryable<BookReview> GetAllBookReviews();
        BookReview GetBookReviewById(int id);
        IQueryable<BookReview> GetBookReviewsByBook(Book book);
        void AddBookReview(BookReview review);
        void UpdateBookReview(BookReview review);
        void DeleteBookReview(int id);
        IQueryable<BookReview> GetBookReviewsByBookId(int id);
        bool BookReviewExists(int id);
    }
}
