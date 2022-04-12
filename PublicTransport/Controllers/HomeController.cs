using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PublicTransport.Core.Constants;
using PublicTransport.Core.Contracts;
using PublicTransport.Core.Models.Home;
using PublicTransport.Models;
using System.Diagnostics;

namespace PublicTransport.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INewsService news;
        private readonly IMemoryCache cache;

        public HomeController(ILogger<HomeController> logger, INewsService news, IMemoryCache cache)
        {
            _logger = logger;
            this.news = news;
            this.cache = cache;
        }

        public IActionResult Index()
        {
            ViewData[MessageConstants.SuccessMessage] = "Добре дошли!";

            return View(new HomePageModel
            {
                 News = this.news.GetTopThreeNews()
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}