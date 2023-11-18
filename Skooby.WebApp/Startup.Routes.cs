using Microsoft.AspNetCore.Builder;

namespace Skooby.WebApp
{
    public partial class Startup
    {
        private void ConfigureRoutes(IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Privacy}/{id?}");
                endpoints.MapControllerRoute(
                    name: "token",
                    pattern: "api/{token}");
                endpoints.MapRazorPages();
            });
        }
    }
}