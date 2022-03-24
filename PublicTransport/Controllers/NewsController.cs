using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Core.Constants;
using PublicTransport.Core.Contracts;
using PublicTransport.Core.Extensions;
using PublicTransport.Models.News;

namespace PublicTransport.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService news;
        private readonly IUserService users;

        public NewsController(INewsService news, IUserService users)
        {
            this.news = news;
            this.users = users;
        }

        public IActionResult All()
        {
            return View();
        }

        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(NewsAddFormModel news)
        {
            var dealerId = this.users.IdByUser(this.User.Id());

            if (dealerId == null)
            {
                ViewData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var newsId = this.news.CreateNews(
                news.Title,
                news.Description,
                DateTime.Now,
                dealerId,
                news.Title,
                false);

            ViewData[MessageConstants.SuccessMessage] = "Новината беше успешно добавена.";

            return RedirectToAction(nameof(Index));
        }
    }
}
