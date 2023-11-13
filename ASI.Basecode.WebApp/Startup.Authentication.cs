﻿using Basecode.Data;
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,              // Clock skew compensates for server time drift.We recommend 5 minutes or less
                    IssuerSigningKey = authSecretKey,       // Specify the key used to sign the token
                    
                    RequireSignedTokens = true,             // Requires that valid tokens should be signed
                    RequireExpirationTime = true,           // Requires that tokens should have expiry date and time

                    ValidIssuer = Configuration[Constants.Token.Issuer],           // Validate the JWT Issuer (iss) claim
                    ValidAudience = Configuration[Constants.Token.Audience],       // Validate the JWT Audience (aud) claim
                    
                    ValidateIssuer = true,              // Validate if the token was issued by a trusted authorization server (default true)
                    ValidateIssuerSigningKey = true,    // Validate the token signing key
                    ValidateAudience = true,            // Validate if the token audience matches our audience value (default true)
                    ValidateLifetime = true,            // Validate the token expiry 
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
