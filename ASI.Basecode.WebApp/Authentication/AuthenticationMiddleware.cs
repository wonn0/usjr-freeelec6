/*using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ASI.Basecode.WebApp.Authentication
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.User.Identity.IsAuthenticated && !context.Request.Path.StartsWithSegments("/Account/Login"))
            {
                // Redirect unauthenticated users to the login page
                context.Response.Redirect("/Account/Login"); // Replace with your desired login page URL
                return;
            }

            await _next(context);
        }
    }
}
*/