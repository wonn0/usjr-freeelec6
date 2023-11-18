using Microsoft.Extensions.DependencyInjection;

namespace Skooby.WebApp
{
    public partial class Startup
    {
        private void ConfigureMVC(IServiceCollection services)
        {
            services.AddMvc();
        }
    }
}