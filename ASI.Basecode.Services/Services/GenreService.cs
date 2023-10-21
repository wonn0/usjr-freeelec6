using ASI.Basecode.Services.Models;
using AutoMapper;
using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using ASI.Basecode.WebApp.Services;
using ASI.Basecode.Data.Repositories;
using System.IO;

namespace ASI.Basecode.Services.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public IEnumerable<GenreViewModel> GetAllGenres()
        {
            var genres = _genreRepository.GetAllGenres();
            return _mapper.Map<IEnumerable<GenreViewModel>>(genres);
        }

        public GenreViewModel GetGenreById(int id)
        {
            var genre = _genreRepository.GetGenreById(id);
            return _mapper.Map<GenreViewModel>(genre);
        }

        public void AddGenre(GenreViewModel model)
        {
            if (!_genreRepository.GenreExists(model.Id))
            {
                var genre = _mapper.Map<Genre>(model);
                _genreRepository.AddGenre(genre);
            }
            else
            {
                throw new InvalidDataException(Resources.Messages.Errors.UserExists);
            }
        }

        public void UpdateGenre(GenreViewModel model)
        {

            if (_genreRepository.GenreExists(model.Id))
            {
                var existingGenre = _genreRepository.GetGenreById(model.Id);
                _mapper.Map(model, existingGenre);
                _genreRepository.UpdateGenre(existingGenre);
            }
        }

        public void DeleteGenre(int id)
        {
            _genreRepository.DeleteGenre(id);
        }
    }
}
