using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Core.Constants;
using PublicTransport.Core.Contracts;
using PublicTransport.Core.Extensions;
using PublicTransport.Infrastructure.Data;
using PublicTransport.Core.Models.News;
using AutoMapper;
using PublicTransport.Core.Models.NewsComments;
using Microsoft.Extensions.Caching.Memory;

namespace PublicTransport.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService news;
        private readonly IUserService users;
        private readonly INewsCommentsService comments;
        private readonly IMemoryCache cache;

        public NewsController(INewsService news, IUserService users, INewsCommentsService comments, IMemoryCache cache)
        {
            this.news = news;
            this.users = users;
            this.comments = comments;
            this.cache = cache;
        }

        public IActionResult All(int p = 1, int s = 10)
        {
            const string latestNewsCacheKey = "latestNewsCacheKey";

            var latestNews = this.cache.Get<NewsPaginationModel>(latestNewsCacheKey);

            if (latestNews == null)
            {
                latestNews = this.news.All(p, s);

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                this.cache.Set(latestNewsCacheKey, latestNews, cacheOptions);
            }

            return View(latestNews);
        }

        public IActionResult Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var news = this.news.Details(id);

            if (news == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction("All");
            }

            return View(news);
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Add(NewsAddFormModel news)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var newsId = this.news.CreateNews(
                news.Title,
                news.Description,
                DateTime.Now,
                userId,
                news.ImgUrl,
                false);

            TempData[MessageConstants.SuccessMessage] = "Новината беше успешно добавена.";
            return RedirectToAction("All");
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Edit(Guid id)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var news = this.news.Details(id);

            var newsForm = this.news.EditViewData(news.Id);

            return View(newsForm);
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Edit(Guid id, NewsAddFormModel news)
        {

            var edited = this.news.Edit(
                id,
                news.Title,
                news.Description,
                news.ImgUrl);

            if (!edited)
            {
                return BadRequest();
            }

            TempData[MessageConstants.SuccessMessage] = "Новината беше успешно редактирана.";
            return RedirectToAction("All");
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Delete(Guid id)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var news = this.news.Details(id);

            var newsForm = this.news.DeleteViewData(news.Id);

            return View(newsForm);
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Delete(Guid id, NewsDeleteModel news)
        {

            var deleted = this.news.Delete(id, true);

            if (!deleted)
            {
                return BadRequest();
            }

            TempData[MessageConstants.SuccessMessage] = "Новината беше успешно изтрита.";
            return RedirectToAction("All");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(Guid id, CommentAddFormModel comment)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var edited = this.comments.CreateNewsComment(
                comment.Content,
                DateTime.Now,
                userId,
                id);

            TempData[MessageConstants.SuccessMessage] = "Успешно публикувахте коментар.";
            return Redirect(Request.Path);
        }
    }
}
