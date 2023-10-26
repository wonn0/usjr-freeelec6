using Microsoft.Extensions.DependencyInjection;

namespace ASI.Basecode.WebApp
{
    public partial class Startup1
    {
        private void ConfigureMVC(IServiceCollection services)
        {
            services.AddMvc();
        }
    }
}
