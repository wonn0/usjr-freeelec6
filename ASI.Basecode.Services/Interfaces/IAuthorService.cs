using ASI.Basecode.Services.Models;
using System.Collections.Generic;

namespace ASI.Basecode.WebApp.Services
{
    public interface IAuthorService
    {
        List<AuthorViewModel> GetAllAuthors();
        AuthorViewModel GetAuthorById(int id);
        void AddAuthor(AuthorViewModel model);
        void UpdateAuthor(AuthorViewModel model);
        void DeleteAuthor(int id);
    }
}
