using ASI.Basecode.Data;
using ASI.Basecode.Resources.Constants;
using Basecode.Data;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;



namespace Basecode.WebApp.Authentication
{
    public class ClaimsProvider
    {
        private readonly IUserService _userService;

        /// <summary>
        ///     Constructor for IUserService
        /// </summary>
        /// <param name="userService"></param>
        public ClaimsProvider(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        ///     Used to retreive claimsIdentity for access token generation
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> GetClaimsIdentityAsync(string username, string password, AsiBasecodeDBContext db)
        { 
            ClaimsIdentity claimsIdentity = null;

            var user = await _userService.FindUserAsync(username, password);
            if (user == null)
            {
                return await Task.FromResult<ClaimsIdentity>(null);
            }

            claimsIdentity = CreateClaimsIdentity(user, db);
            return await Task.FromResult(claimsIdentity);
        }

        /// <summary>
        ///      Used to retreive claimsIdentity for refresh token generation
        /// </summary>
        /// <param name="username"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> GetIdentityAsync(string username, AsiBasecodeDBContext db)
        {
            ClaimsIdentity claimsIdentity = null;

            var user = _userService.FindUser(username);
            if (user == null)
            {
                return await Task.FromResult<ClaimsIdentity>(null);
            }

            claimsIdentity = CreateClaimsIdentity(user, db);
            return await Task.FromResult(claimsIdentity);
        }

        /// <summary>
        ///     Adds claims to claimsIdentity
        /// </summary>
        /// <param name="user"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public ClaimsIdentity CreateClaimsIdentity(IdentityUser user, AsiBasecodeDBContext db)
        {
            var now = DateTime.UtcNow;
            var claims = new List<Claim>();

            var userRoles = db.UserRoles.Where(i => i.UserId == user.Id);
            foreach (var u in userRoles)
            {
                var role = db.Roles.Single(i => i.Id == u.RoleId);
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            claims.Add(new Claim(Constants.ClaimTypes.UserName, user.UserName));            
            claims.Add(new Claim(Constants.ClaimTypes.ID, user.Id.ToString()));
            claims.Add(new Claim(Constants.ClaimTypes.UserId, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));            

            return new ClaimsIdentity(claims);
        }
    }
}
