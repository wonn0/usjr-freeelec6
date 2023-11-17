using Microsoft.AspNetCore.Builder;

namespace ASI.Basecode.WebApp
{
    public partial class Startup
    {
        private void ConfigureRoutes(IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
                endpoints.MapControllerRoute(
                    name: "token",
                    pattern: "api/{token}");
                endpoints.MapRazorPages();
            });
        }
    }
}