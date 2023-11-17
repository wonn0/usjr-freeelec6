using ASI.Basecode.Services.Models;
using System.Collections.Generic;

namespace ASI.Basecode.WebApp.Services
{
    public interface IBookService
    {
        List<BookViewModel> GetAllBooks();
        BookViewModel GetBookById(int id);
        void AddBook(BookViewModel model);
        void UpdateBook(BookViewModel model);
        void DeleteBook(int id);
        List<BookViewModel> GetBooksByAuthor(int authorId);
    }

}
