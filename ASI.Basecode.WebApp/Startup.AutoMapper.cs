using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.ServiceModels;
using AutoMapper;
using Basecode.Data.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ASI.Basecode.WebApp
{
    public partial class Startup
    {
        private void ConfigureMapper(IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile(new AutoMapperProfileConfiguration());
            });

            services.AddSingleton<IMapper>(sp => mapperConfiguration.CreateMapper());
            /*var Config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JobOpening, JobOpeningViewModel>();
            });

            services.AddSingleton(Config.CreateMapper());*/
        }

        private class AutoMapperProfileConfiguration : Profile
        {
            public AutoMapperProfileConfiguration()
            {
                CreateMap<UserViewModel, User>();
            }
        }
    }
}