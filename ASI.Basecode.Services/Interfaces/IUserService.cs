using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.ServiceModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ASI.Basecode.Resources.Constants.Enums;

namespace ASI.Basecode.Services.Interfaces
{
    public interface IUserService
    {
        LoginResult AuthenticateUser(string userid, string password, ref User user);
        void AddUser(UserViewModel model);
        IdentityUser FindUser(string userName);
        List<UserViewModel> GetAllUsers();
        Task<IdentityUser> FindUserAsync(string userName, string password);
        Task<IdentityResult> CreateRole(string roleName);
    }
}