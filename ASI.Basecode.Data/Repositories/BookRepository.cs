using ASI.Basecode.Data.Interfaces;
using Basecode.Data.Repositories;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ASI.Basecode.Data.Repositories
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IQueryable<Book> GetAllBooks()
        {
            return this.GetDbSet<Book>().Include(b => b.AuthorBooks)
                           .ThenInclude(ab => ab.Author)
                       .Include(b => b.BookGenres)
                           .ThenInclude(bg => bg.Genre);
        }

        public IQueryable<Book> GetNewestBooksPaginated(int pageNo, int pageSize)
        {
            // indicate how many pages to skip
            int pagesToSkip = (pageNo - 1) * pageSize;

            return this.GetDbSet<Book>()
                        .Include(b => b.AuthorBooks)
                           .ThenInclude(ab => ab.Author)
                       .Include(b => b.BookGenres)
                           .ThenInclude(bg => bg.Genre)
                       // sort by publish data (newest books, edit to OrderByAscending if other way around)
                       .OrderByDescending(b => b.PublishedOn)
                       // skip pages by x amount and take y amount per page for pagination
                       .Skip(pagesToSkip)
                       .Take(pageSize);
        }

        //public IQueryable<Book> GetTopRatedBooksPaginated(int pageNo, int pageSize)
        //{
        //    int pagesToSkip = (pageNo - 1) * pageSize;

        //    return this.GetDbSet<Book>()
        //                .Include(b => b.AuthorBooks)
        //                   .ThenInclude(ab => ab.Author)
        //               .Include(b => b.BookGenres)
        //                   .ThenInclude(bg => bg.Genre)
        //               .OrderByDescending(b => b.PublishedOn)
        //               .Skip(pagesToSkip)
        //               .Take(pageSize);
        //}

        public IQueryable<Book> GetBookByAuthorId(int authorId, int currentBookId)
        {
            return this.GetDbSet<Book>()
                       .Where(book => book.Id != currentBookId)
                       .Include(b => b.AuthorBooks)
                       .Where(ab => ab.AuthorBooks.Any(a => a.AuthorId == authorId))
                       .Include(b => b.BookGenres)
                       .ThenInclude(bg => bg.Genre);
        }

        public Book GetBookById(int id)
        {
            return this.GetDbSet<Book>().Include(b => b.AuthorBooks)
                           .ThenInclude(ab => ab.Author)
                       .Include(b => b.BookGenres)
                           .ThenInclude(bg => bg.Genre)
                       .FirstOrDefault(b => b.Id == id);
        }

        public bool BookExists(int bookId)
        {
            return this.GetDbSet<Book>().Any(x => x.Id == bookId);
        }

        public void AddBook(Book book)
        {
            this.GetDbSet<Book>().Add(book);
            UnitOfWork.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            this.SetEntityState(book, EntityState.Modified);
            UnitOfWork.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = this.GetBookById(id);
            if (book != null)
            {
                this.GetDbSet<Book>().Remove(book);
                UnitOfWork.SaveChanges();
            }
        }

    }
}
