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

        //[Authorize(Roles = UserConstants.Administrator)]
        //public async Task<IActionResult> CreateRole()
        //{
        //    await roleManager.CreateAsync(new IdentityRole()
        //    {
        //        Name = "Карти и билети"
        //    });

        //    return Ok();
        //}

        [Authorize(Roles = $"{UserConstants.Administrator},{UserConstants.PhotoModerator}")]
        public IActionResult ApprovePhotos(int p = 1, int s = 10)
        {
            var loggedUserId = this.users.IdByUser(this.User.Id());

            if (loggedUserId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var allMyPhotosForm = this.admins.AllPendingPhotos(p, s);

            return View(allMyPhotosForm);
        }

        [Authorize(Roles = $"{UserConstants.Administrator},{UserConstants.PhotoModerator}")]
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
        [Authorize(Roles = $"{UserConstants.Administrator},{UserConstants.PhotoModerator}")]
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

        [Authorize(Roles = $"{UserConstants.Administrator},{UserConstants.PhotoModerator}")]
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
        [Authorize(Roles = $"{UserConstants.Administrator},{UserConstants.PhotoModerator}")]
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

        [Authorize(Roles = $"{UserConstants.Administrator},{UserConstants.CardsAndTikets}")]
        public IActionResult CardRequests(int p = 1, int s = 10)
        {
            var loggedUserId = this.users.IdByUser(this.User.Id());

            if (loggedUserId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var allCardForm = this.admins.AllPendingCards(p, s);

            return View(allCardForm);
        }

        [Authorize(Roles = $"{UserConstants.Administrator},{UserConstants.CardsAndTikets}")]
        public IActionResult Reject(string id)
        {
            var deleted = this.admins.RejectCard(id);

            if (!deleted)
            {
                return BadRequest();
            }

            TempData[MessageConstants.SuccessMessage] = "Успешно отказахте заявената абонаментна карта на потребителя.";
            return Redirect("../../Admin/CardRequests");
        }

        [Authorize(Roles = $"{UserConstants.Administrator},{UserConstants.CardsAndTikets}")]
        public IActionResult CardActivate(string id)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var approveForm = this.admins.CardActivateViewData(id);

            return View(approveForm);
        }

        [HttpPost]
        [Authorize(Roles = $"{UserConstants.Administrator},{UserConstants.CardsAndTikets}")]
        public IActionResult CardActivate(string id, AdminActivateCardModel card)
        {
            var activateCardData = this.admins.CardActivateViewData(id);
            var approved = this.admins.ActivateCard(id, card.CardActiveFrom.Value, activateCardData.RequestedCard);

            if (!approved)
            {
                TempData[MessageConstants.ErrorMessage] = "Не може да задавате дата преди днешната.";
                return Redirect($"../../Admin/CardActivate/{id}");
            }
            if(card.CardActiveTo.HasValue)

            TempData[MessageConstants.SuccessMessage] = "Успешно активирахте тази карта.";
            return Redirect("../../Admin/CardRequests");
        }
    }
}
