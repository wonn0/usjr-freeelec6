using Data.Models;
using System.Linq;

namespace Data.Interfaces
{
    public interface IBookReviewCommentRepository
    {
        IQueryable<BookReviewComment> GetAllBookReviewComments();
        BookReviewComment GetBookReviewCommentById(int id);
        IQueryable<BookReviewComment> GetBookReviewCommentsByReview(BookReview review);
        void AddBookReviewComment(BookReviewComment comment);
        void UpdateBookReviewComment(BookReviewComment comment);
        void DeleteBookReviewComment(int id);
        bool BookReviewCommentExists(int id);
    }
}
