using Data.Models;
using System.Linq;

namespace Data.Interfaces
{
    public interface IGenreRepository
    {
        IQueryable<Genre> GetAllGenres();
        Genre GetGenreById(int id);
        void AddGenre(Genre Genre);
        void UpdateGenre(Genre Genre);
        void DeleteGenre(int id);
        bool GenreExists(int id);
    }
}
