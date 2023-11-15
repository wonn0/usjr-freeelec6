using ASI.Basecode.Data.Interfaces;
using Basecode.Data.Repositories;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ASI.Basecode.Data.Repositories
{
    public class BookReviewCommentRepository : BaseRepository, IBookReviewCommentRepository
    {
        public BookReviewCommentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IQueryable<BookReviewComment> GetAllBookReviewComments()
        {
            return this.GetDbSet<BookReviewComment>();
        }

        public BookReviewComment GetBookReviewCommentById(int id)
        {
            return this.GetDbSet<BookReviewComment>().Find(id);
        }

        public IQueryable<BookReviewComment> GetBookReviewCommentsByReview(BookReview review)
        {
            return this.GetDbSet<BookReviewComment>().Where(x => x.ReviewId == review.Id);
        }


        public void AddBookReviewComment(BookReviewComment comment)
        {
            this.GetDbSet<BookReviewComment>().Add(comment);
            UnitOfWork.SaveChanges();
        }

        public void UpdateBookReviewComment(BookReviewComment comment)
        {
            this.SetEntityState(comment, EntityState.Modified);
            UnitOfWork.SaveChanges();
        }

        public void DeleteBookReviewComment(int id)
        {
            var comment = this.GetDbSet<BookReviewComment>().Find(id);
            if (comment != null)
            {
                this.GetDbSet<BookReviewComment>().Remove(comment);
                UnitOfWork.SaveChanges();
            }
        }

        public bool BookReviewCommentExists(int id)
        {
            return this.GetDbSet<BookReviewComment>().Any(x => x.Id == id);
        }
    }
}
