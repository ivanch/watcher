using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Watcher.Contracts.Services;
using Watcher.Models;

namespace Watcher.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebsiteService websiteService;
        private readonly ILogger<HomeController> logger;

        public HomeController(IWebsiteService websiteService, ILogger<HomeController> logger)
        {
            this.websiteService = websiteService;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddWebsite()
        {
            return View();
        }

        public IActionResult Add(Website website)
        {
            website.User = "default";
            websiteService.AddWebsite(website);

            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}