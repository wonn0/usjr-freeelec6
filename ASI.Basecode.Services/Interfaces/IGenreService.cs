using ASI.Basecode.Services.Models;
using System.Collections.Generic;

namespace ASI.Basecode.WebApp.Services
{
    public interface IGenreService
    {
        List<GenreViewModel> GetAllGenres();
        GenreViewModel GetGenreById(int id);
        void AddGenre(GenreViewModel model);
        void UpdateGenre(GenreViewModel model);
        void DeleteGenre(int id);
    }
}
