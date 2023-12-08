using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.ServiceModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static ASI.Basecode.Resources.Constants.Constants;
using System.Linq;
using System.Collections.Generic;

namespace ASI.Basecode.WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ILogger<AdminController> _logger;

        public AdminController(UserManager<IdentityUser> userManager, IMapper mapper, ILogger<AdminController> logger)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult Dashboard()
        {
            //var isSuperAdmin = User.IsInRole("SuperAdmin");
            ViewBag.ShowSideBar = true;
            //ViewBag.ShowUserList = isSuperAdmin;
            return View();
        }
        public async Task<IActionResult> IndexAsync(string searchQuery)
        {
            IEnumerable<IdentityUser> users;

            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                users = await _userManager.Users.ToListAsync();
                _logger.LogInformation("Loaded all users");
            }
            else
            {
                users = await _userManager.Users
                    .Where(u => u.UserName.Contains(searchQuery) || u.Email.Contains(searchQuery))
                    .ToListAsync();
                _logger.LogInformation("Loaded users with search query: {SearchQuery}", searchQuery);
            }

            return View(users);
        }


        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, IdentityUser userToUpdate)
        {
            if (id != userToUpdate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByIdAsync(id);
                    if (user == null)
                    {
                        return NotFound();
                    }

                    user.Email = userToUpdate.Email;
                    user.UserName = userToUpdate.UserName;
                    // Update other fields as needed

                    await _userManager.UpdateAsync(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await UserExists(userToUpdate.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Admin");
            }
            return View(userToUpdate);
        }

        private async Task<bool> UserExists(string id)
        {
            return await _userManager.FindByIdAsync(id) != null;
        }

        // POST: Admin/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            _logger.LogInformation("HER");
            _logger.LogInformation("asd");
            var user = await _userManager.FindByIdAsync(id);
            _logger.LogInformation($"User: {user.UserName}");
            try
            { 
                if (user != null)
                {
                    await _userManager.DeleteAsync(user);
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the user with ID {UserId}", id);

            }
            return RedirectToAction("Index", "Admin");
        }

    }
}