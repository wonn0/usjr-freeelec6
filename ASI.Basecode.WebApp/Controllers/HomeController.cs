using ASI.Basecode.WebApp.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ASI.Basecode.WebApp.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    public class HomeController : ControllerBase<HomeController>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="configuration"></param>
        /// <param name="localizer"></param>
        /// <param name="mapper"></param>
        public HomeController(IHttpContextAccessor httpContextAccessor,
                              ILoggerFactory loggerFactory,
                              IConfiguration configuration,
                              IMapper mapper = null)
            : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            // Assuming _logger is initialized in the base class.
        }

        /// <summary>
        /// Returns Home View.
        /// </summary>
        /// <returns> Home View </returns>
        public IActionResult Index()
        {
            // Use _logger to log the information
            _logger.LogInformation("Home page visited at {Time}", System.DateTime.Now);

            return View();
        }
        public IActionResult ViewBook()
        {
            // Use _logger to log the information
            _logger.LogInformation("ViewBook page visited at {Time}", System.DateTime.Now);

            return View();
        }

        // ... other actions
    }
}
