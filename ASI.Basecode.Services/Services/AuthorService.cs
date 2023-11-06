using ASI.Basecode.Services.Models;
using ASI.Basecode.WebApp.Services;
using AutoMapper;
using Data.Interfaces;
using Data.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ASI.Basecode.Services.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public List<AuthorViewModel> GetAllAuthors()
        {
            var authors = _authorRepository.GetAllAuthors();
            return _mapper.Map<IEnumerable<AuthorViewModel>>(authors).ToList();
        }

        public AuthorViewModel GetAuthorById(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            return _mapper.Map<AuthorViewModel>(author);
        }

        public void AddAuthor(AuthorViewModel model)
        {
            if (!_authorRepository.AuthorExists(model.Id))
            {
                var author = _mapper.Map<Author>(model);
                _authorRepository.AddAuthor(author);
            }
            else
            {
                throw new InvalidDataException(Resources.Messages.Errors.UserExists);
            }
        }

        public void UpdateAuthor(AuthorViewModel model)
        {
            if (_authorRepository.AuthorExists(model.Id))
            {
                var existingAuthor = _authorRepository.GetAuthorById(model.Id);
                _mapper.Map(model, existingAuthor);
                _authorRepository.UpdateAuthor(existingAuthor);
            }
        }

        public void DeleteAuthor(int id)
        {
            _authorRepository.DeleteAuthor(id);
        }
    }
}
