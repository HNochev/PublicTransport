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

namespace PublicTransport.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService news;
        private readonly IUserService users;
        private readonly INewsCommentsService comments;

        public NewsController(INewsService news, IUserService users, INewsCommentsService comments)
        {
            this.news = news;
            this.users = users;
            this.comments = comments;
        }

        public IActionResult All()
        {
            var news = this.news.All();

            return View(news);
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

        [Authorize]
        public IActionResult _PartialAddComment(Guid Id)
        {
            return View();
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
