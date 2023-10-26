using AutoMapper;
using Basecode.Data.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ASI.Basecode.WebApp
{
    public partial class Startup1
    {
        private void ConfigureMapper(IServiceCollection services)
        {
            /*var Config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JobOpening, JobOpeningViewModel>();
            });

            services.AddSingleton(Config.CreateMapper());*/
        }
    }
}