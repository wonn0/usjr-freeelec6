﻿using ASI.Basecode.Data;
using ASI.Basecode.Resources.Constants;
using Basecode.WebApp.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASI.Basecode.WebApp.Authentication
{
    /// <summary>
    /// Token Provider Middleware
    /// </summary>
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;
        private ClaimsProvider _claimsProvider;

        /// <summary>
        ///     Constructor for RequestDelegate and IOptions
        /// </summary>
        /// <param name="next"></param>
        /// <param name="options"></param>
        public TokenProviderMiddleware(RequestDelegate next, IOptions<TokenProviderOptions> options)
        {
            _next = next;
            _options = options.Value;
        }

        /// <summary>
        ///     Catches context path for logging in
        /// </summary>
        /// <param name="context"></param>
        /// <param name="claimsProvider"></param>
        /// <returns></returns>
        public Task Invoke(HttpContext context, ClaimsProvider claimsProvider)
        {
            // If the request path doesn't match, return request
            if ((!context.Request.Path.Equals(_options.Path, StringComparison.Ordinal)))
            {
                return _next(context);
            }

            _claimsProvider = claimsProvider;

            return GenerateToken(context);
        }

        /// <summary>
        ///     Handles Access token generation
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task GenerateToken(HttpContext context)
        {
            var stream = context.Request.Body;
            string json = new StreamReader(stream).ReadToEnd();
            var user = JObject.Parse(json);

            var username = user[Constants.Token.Username].ToString();
            var password = user[Constants.Token.Password].ToString();

            var db = context.RequestServices.GetService<AsiBasecodeDBContext>();

            var identity = await _claimsProvider.GetClaimsIdentityAsync(username, password, db);
            if (identity == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(Constants.User.InvalidUserNamePassword);
                return;
            }

            var userManager = context.RequestServices.GetService<UserManager<IdentityUser>>();

            var id = identity.Claims.Where(c => c.Type == Constants.Token.UserID)
                   .Select(c => c.Value).SingleOrDefault();

            var userRole = db.UserRoles
                .SingleOrDefault(i => i.UserId == id);

            if (userRole == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync("No user role");
                return;
            }

            var userDb = await userManager.FindByNameAsync(username);

            var response = GetAuthResponse.Execute(identity, db, userDb);
            context.Response.ContentType = Constants.Common.JSONContentType;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }
    }
}
