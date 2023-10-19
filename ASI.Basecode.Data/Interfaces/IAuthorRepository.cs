using Data.Models;
using System.Linq;

namespace Data.Interfaces
{
    public interface IAuthorRepository
    {
        IQueryable<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        void AddAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(int id);
        bool AuthorExists(int id);
    }
}
