using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Basecode.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserRepository(IUnitOfWork unitOfWork,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager) : base(unitOfWork) 
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IQueryable<User> GetUsers()
        {
            return this.GetDbSet<User>();
        }

        public bool UserExists(string userId)
        {
            return this.GetDbSet<User>().Any(x => x.UserId == userId);
        }

        public void AddUser(User user)
        {
            this.GetDbSet<User>().Add(user);
            UnitOfWork.SaveChanges();
        }
        public IdentityUser FindUser(string userName)
        {
            var userDB = GetDbSet<IdentityUser>().Where(x => x.UserName.ToLower().Equals(userName.ToLower())).AsNoTracking().FirstOrDefault();
            return userDB;
        }

        public async Task<IdentityUser> FindUserAsync(string userName, string password)
        {
            var userDB = GetDbSet<IdentityUser>().Where(x => x.UserName.ToLower().Equals(userName.ToLower())).AsNoTracking().FirstOrDefault();
            var user = await _userManager.FindByNameAsync(userName);
            var isPasswordOK = await _userManager.CheckPasswordAsync(user, password);
            if ((user == null) || (isPasswordOK == false))
            {
                userDB = null;
            }
            return userDB;
        }

        public async Task<IdentityResult> CreateRole(string roleName)
        {
            bool checkIfRoleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!checkIfRoleExists)
            {
                var role = new IdentityRole();
                role.Name = roleName;
                var result = await _roleManager.CreateAsync(role);
                return result;
            }

            return null;
        }

    }
}
