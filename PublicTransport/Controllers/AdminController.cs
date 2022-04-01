using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Core.Constants;
using PublicTransport.Core.Contracts;
using PublicTransport.Core.Extensions;
using PublicTransport.Core.Models.Admin;

namespace PublicTransport.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IAdminService admins;
        private readonly IUserService users;
        public AdminController(RoleManager<IdentityRole> roleManager, IAdminService admins, IUserService users)
        {
            this.roleManager = roleManager;
            this.admins = admins;
            this.users = users;
        }

        public IActionResult Index()
        {
            return Ok();
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public async Task<IActionResult> ManageUsers()
        {
            return View();
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public async Task<IActionResult> CreateRole()
        {
            //await roleManager.CreateAsync(new IdentityRole()
            //{
            //    Name = "Администратор"
            //});

            return Ok();
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult ApprovePhotos()
        {
            var loggedUserId = this.users.IdByUser(this.User.Id());

            if (loggedUserId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var allMyPhotosForm = this.admins.AllPendingPhotos();

            return View(allMyPhotosForm);
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Approve(Guid id)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var approveForm = this.admins.ApproveDisapproveViewData(id);

            return View(approveForm);
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Approve(Guid id, AdminApproveDisapprovePhotoModel photo)
        {

            var approved = this.admins.Approve(id, photo.AdminMessage);

            if (!approved)
            {
                return BadRequest();
            }

            TempData[MessageConstants.SuccessMessage] = "Успешно одобрихте тази снимка.";
            return RedirectToAction("ApprovePhotos");
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult DisApprove(Guid id)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var disApproveForm = this.admins.ApproveDisapproveViewData(id);

            return View(disApproveForm);
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult DisApprove(Guid id, AdminApproveDisapprovePhotoModel photo)
        {

            var disApproved = this.admins.DisApprove(id, photo.AdminMessage);

            if (!disApproved)
            {
                return BadRequest();
            }

            TempData[MessageConstants.SuccessMessage] = "Успешно отхвърлихте публикуването на тази снимка.";
            return RedirectToAction("ApprovePhotos");
        }
    }
}
