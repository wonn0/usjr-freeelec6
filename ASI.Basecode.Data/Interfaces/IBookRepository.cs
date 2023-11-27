using Data.Models;
using System.Linq;

namespace Data.Interfaces
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAllBooks();
        IQueryable<Book> GetBookByAuthorId(int authorId);
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        bool BookExists(int id);
    }
}
