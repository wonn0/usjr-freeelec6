using Microsoft.AspNetCore.Builder;

namespace ASI.Basecode.WebApp
{
    public partial class Startup1
    {
        private void ConfigureRoutes(IApplicationBuilder app)
        {            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "token",
                    pattern: "api/{token}");

                endpoints.MapRazorPages();
            });
        }
    }
}
