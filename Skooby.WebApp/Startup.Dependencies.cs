﻿using Microsoft.Extensions.DependencyInjection;
using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Repositories;
using ASI.Basecode.Data;
using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.Services;
using ASI.Basecode.WebApp.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ASI.Basecode.WebApp.Services;
using Data.Interfaces;

namespace Skooby.WebApp
{
    public partial class Startup
    {
        private void ConfigureDependencies(IServiceCollection services)
        {
            // Framework
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            // Common
            services.AddScoped<TokenProvider>();
            services.AddSingleton<TokenProviderOptionsFactory>();
            services.AddSingleton<TokenValidationParametersFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ClaimsProvider, ClaimsProvider>();

            // Services
            services.AddSingleton<TokenValidationParametersFactory>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IBookReviewService, BookReviewService>();

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IBookReviewRepository, BookReviewRepository>();

            // Manager Class
            services.AddScoped<SignInManager>();

            services.AddHttpClient();

        }
    }
}