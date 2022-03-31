using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Core.Constants;
using PublicTransport.Core.Contracts;
using PublicTransport.Core.Extensions;

namespace PublicTransport.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService users;
        private readonly IPhotoService photos;

        public UserController(IUserService users, IPhotoService photos)
        {
            this.users = users;
            this.photos = photos;
        }

        [Authorize]
        public IActionResult MyProfile()
        {
            return View();
        }

        public IActionResult UserProfile(string id)
        {
            var loggedUserId = this.users.IdByUser(this.User.Id());

            if (loggedUserId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var detailsForm = this.users.UserDetails(id);

            return View(detailsForm);
        }

        [Authorize]
        public IActionResult MyPhotos()
        {
            var loggedUserId = this.users.IdByUser(this.User.Id());

            if (loggedUserId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var allMyPhotosForm = this.photos.AllPhotosByUser(loggedUserId);

            return View(allMyPhotosForm);
        }
    }
}
