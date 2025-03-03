﻿using ASI.Basecode.Data.Interfaces;
using Basecode.Data.Repositories;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
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
            return this.GetDbSet<Book>().Include(b => b.Author); ;
        }
        public Book GetBookById(int id)
        {
            return this.GetDbSet<Book>().Include(b => b.Author).FirstOrDefault(b => b.Id == id);
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
            var book = this.GetDbSet<Book>().Find(id);
            if (book != null)
            {
                this.GetDbSet<Book>().Remove(book);
                UnitOfWork.SaveChanges();
            }
        }

    }
}
