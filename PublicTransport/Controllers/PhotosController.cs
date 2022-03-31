using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Core.Constants;
using PublicTransport.Core.Contracts;
using PublicTransport.Core.Extensions;
using PublicTransport.Core.Models.Photos;

namespace PublicTransport.Controllers
{
    public class PhotosController : Controller
    {
        private readonly IPhotoService photos;
        private readonly IUserService users;
        private readonly IVehicleService vehicles;

        public PhotosController(IPhotoService photos, IUserService users, IVehicleService vehicles)
        {
            this.photos = photos;
            this.users = users;
            this.vehicles = vehicles;
        }

        [Authorize]
        public IActionResult Edit(Guid id)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                ViewData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            if (!this.photos.IsByUser(id, userId) && !User.IsInRole(UserConstants.Administrator))
            {
                return BadRequest();
            }

            var commentForm = this.photos.EditViewData(id);

            return View(commentForm);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(Guid id, PhotoEditFormModel photo)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (!this.photos.IsByUser(id, userId) && !User.IsInRole(UserConstants.Administrator))
            {
                return BadRequest();
            }

            var edited = this.photos.Edit(
                id,
                photo.Description,
                photo.DateOfPicture,
                photo.IsAuthor,
                photo.Location,
                photo.UserMessage
                );

            if (!edited)
            {
                return BadRequest();
            }

            TempData[MessageConstants.SuccessMessage] = "Информацията за снимката беше успешно редактирана.";

            return Redirect($"../../Photos/Details/{id}");
        }

        public IActionResult Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var vehicles = this.photos.Details(id);

            if (vehicles == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction("All");
            }

            return View(vehicles);
        }
    }
}
