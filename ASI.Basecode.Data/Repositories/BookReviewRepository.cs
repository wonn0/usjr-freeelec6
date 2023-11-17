using ASI.Basecode.Data.Interfaces;
using Basecode.Data.Repositories;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ASI.Basecode.Data.Repositories
{
    public class BookReviewRepository : BaseRepository, IBookReviewRepository
    {
        public BookReviewRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IQueryable<BookReview> GetAllBookReviews()
        {
            return this.GetDbSet<BookReview>();
        }

        public BookReview GetBookReviewById(int id)
        {
            return this.GetDbSet<BookReview>().Find(id);
        }

        public IQueryable<BookReview> GetBookReviewsByBook(Book book)
        {
            return this.GetDbSet<BookReview>().Where(x => x.BookId == book.Id);
        }
        public IQueryable<BookReview> GetBookReviewsByBookId(int id)
        {
            return this.GetDbSet<BookReview>().Where(x => x.BookId == id);
        }

        public void AddBookReview(BookReview review)
        {
            this.GetDbSet<BookReview>().Add(review);
            UnitOfWork.SaveChanges();
        }

        public void UpdateBookReview(BookReview review)
        {
            this.SetEntityState(review, EntityState.Modified);
            UnitOfWork.SaveChanges();
        }

        public void DeleteBookReview(int id)
        {
            var review = this.GetDbSet<BookReview>().Find(id);
            if (review != null)
            {
                this.GetDbSet<BookReview>().Remove(review);
                UnitOfWork.SaveChanges();
            }
        }

        public bool BookReviewExists(int id)
        {
            return this.GetDbSet<BookReview>().Any(x => x.Id == id);
        }
    }
}
