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
            return View();
        }
        public async Task<IActionResult> IndexAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            _logger.LogInformation("Loaded all users");
            return View(users);
        }


    }
}