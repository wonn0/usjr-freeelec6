using ASI.Basecode.Data.Interfaces;
using Basecode.Data.Repositories;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ASI.Basecode.Data.Repositories
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        public AuthorRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IQueryable<Author> GetAllAuthors()
        {
            return this.GetDbSet<Author>();
        }

        public Author GetAuthorById(int id)
        {
            return this.GetDbSet<Author>().Find(id);
        }

        public void AddAuthor(Author author)
        {
            this.GetDbSet<Author>().Add(author);
            UnitOfWork.SaveChanges();
        }

        public void UpdateAuthor(Author author)
        {
            this.SetEntityState(author, EntityState.Modified);
            UnitOfWork.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            var author = this.GetDbSet<Author>().Find(id);
            if (author != null)
            {
                this.GetDbSet<Author>().Remove(author);
                UnitOfWork.SaveChanges();
            }
        }

        public bool AuthorExists(int id)
        {
            return this.GetDbSet<Author>().Any(x => x.Id == id);
        }
    }
}
