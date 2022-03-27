using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Core.Constants;
using PublicTransport.Core.Contracts;
using PublicTransport.Core.Extensions;
using PublicTransport.Infrastructure.Data;
using PublicTransport.Models.News;

namespace PublicTransport.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService news;
        private readonly IUserService users;
        private readonly ApplicationDbContext data;

        public NewsController(INewsService news, IUserService users, ApplicationDbContext data)
        {
            this.news = news;
            this.users = users;
            this.data = data;
        }

        public IActionResult All()
        {
            var news = this.data
                .News
                .Where(x => !x.IsDeleted)
                .Select(x => new NewsListingModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = this.news.Truncate(x.Description, 200),
                    ImgUrl = x.ImgUrl,
                    Date = x.Date,
                    IsDeleted = x.IsDeleted,
                    AuthorId = x.AuthorId,
                    Author = x.Author,
                })
                .OrderByDescending(x => x.Date)
                .ToList();

            return View(news);
        }

        public IActionResult Details(Guid id)
        {
            if(id == Guid.Empty)
            {
                ViewData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var news = this.data.News
                .Include(x => x.Author)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return View(news);
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
                news.ImgUrl,
                false);

            ViewData[MessageConstants.SuccessMessage] = "Новината беше успешно добавена.";

            return RedirectToAction("All");
        }
    }
}
