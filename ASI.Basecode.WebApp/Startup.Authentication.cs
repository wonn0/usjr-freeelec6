using Basecode.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using ASI.Basecode.WebApp.Authentication;
using ASI.Basecode.Resources.Constants;
using System;

namespace ASI.Basecode.WebApp
{
    public partial class Startup
    {
        private void ConfigureAuth(IServiceCollection services)
        {
            var authSecretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration[Constants.Token.SecretKey]));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    var secretKey = Configuration["TokenAuthentication:SecretKey"];
    var audience = Configuration["TokenAuthentication:Audience"];
    var issuer = Configuration["TokenAuthentication:Issuer"]; // Optional: Add this line if Issuer is added in appsettings.json

    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
        ValidIssuer = issuer, // Use the `issuer` variable
        ValidAudience = audience, // Use the `audience` variable
        RequireSignedTokens = true,
        RequireExpirationTime = true,
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidateAudience = true,
        ValidateLifetime = true,
    };
});

            services.AddMvc();

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Error/Forbidden";
            });
        }

        private void ConfigureAuth(IApplicationBuilder app)
        {
            app.UseMiddleware<TokenProviderMiddleware>();
            app.UseMiddleware<RefreshTokenProviderMiddleware>();
        }
    }
}
