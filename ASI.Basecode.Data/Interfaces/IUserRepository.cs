using ASI.Basecode.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsers();
        bool UserExists(string userId);
        void AddUser(User user);
        IdentityUser FindUser(string userName);
        Task<IdentityUser> FindUserAsync(string userName, string password);
        Task<IdentityResult> CreateRole(string roleName);
    }
}
