using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.ServiceModels;
using ASI.Basecode.Services.Models;
using AutoMapper;
using Data.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ASI.Basecode.WebApp
{
    // AutoMapper configuration
    internal partial class StartupConfigurer
    {
        /// <summary>
        /// Configure auto mapper
        /// </summary>
        private void ConfigureAutoMapper()
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile(new AutoMapperProfileConfiguration());
            });

            this._services.AddSingleton<IMapper>(sp => mapperConfiguration.CreateMapper());
        }

        private class AutoMapperProfileConfiguration : Profile
        {
            public AutoMapperProfileConfiguration()
            {
                CreateMap<UserViewModel, User>();

                CreateMap<Book, BookViewModel>()
                    .ForMember(dest => dest.AuthorNames, opt => opt.MapFrom(src => src.AuthorBooks.Select(ba => ba.Author.FirstName + " " + ba.Author.LastName)))
                    .ForMember(dest => dest.AuthorIds, opt => opt.MapFrom(src => src.AuthorBooks.Select(ba => ba.AuthorId)))
                    .ForMember(dest => dest.GenreIds, opt => opt.MapFrom(src => src.BookGenres.Select(bg => bg.GenreId)))
                    .ForMember(dest => dest.GenreNames, opt => opt.MapFrom(src => src.BookGenres.Select(bg => bg.Genre.Name)));
                CreateMap<BookViewModel, Book>();

                //Auto-Mapper configuration for authors
                CreateMap<Author, AuthorViewModel>();
                CreateMap<AuthorViewModel, Author>();

                //Auto-Mapper configuration for genres
                CreateMap<Genre, GenreViewModel>();
                CreateMap<GenreViewModel, Genre>();

                CreateMap<BookReview, BookReviewViewModel>()
                    .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Book.Name));
                CreateMap<BookReviewViewModel, BookReview>();
            }
        }
    }
}
