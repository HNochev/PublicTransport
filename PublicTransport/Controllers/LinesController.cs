using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Core.Constants;
using PublicTransport.Core.Contracts;
using PublicTransport.Core.Extensions;
using PublicTransport.Core.Models.Lines;

namespace PublicTransport.Controllers
{
    public class LinesController : Controller
    {
        private readonly ILineService lines;
        private readonly IUserService users;

        public LinesController(ILineService lines, IUserService users)
        {
            this.lines = lines;
            this.users = users;
        }

        public IActionResult All()
        {
            if (this.User.IsInRole(UserConstants.Administrator))
            {
                var lines = this.lines.AllWithNotActive();
                return View(lines);
            }
            else
            {
                var lines = this.lines.AllActive();
                return View(lines);
            }

        }

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult AddStop()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult AddStop(StopAddFormModel stop)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var stopId = this.lines.CreateStop(
                stop.Name,
                stop.MinutesFromPreviousStop);

            TempData[MessageConstants.SuccessMessage] = "Успешно добавихте спирка в базата.";
            return RedirectToAction("All");
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult AddLine()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult AddLine(LineAddFormModel line)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var stopId = this.lines.CreateLine(
                line.Name,
                line.Description,
                line.IsActive,
                userId);

            TempData[MessageConstants.SuccessMessage] = "Успешно добавихте линията в базата.";
            return RedirectToAction("All");
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult ActivateDisactivateLine(Guid id)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var isActive = this.lines.IsActive(id);

            var activated = this.lines.ActivateDeactivate(id);

            if (!activated)
            {
                return BadRequest();
            }
            if (!isActive)
            {
                TempData[MessageConstants.SuccessMessage] = "Успешно активирахте линията.";
            }
            else
            {
                TempData[MessageConstants.SuccessMessage] = "Успешно деактивирахте линията.";
            }
            return Redirect($"../../Lines/All");
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult EditLine(Guid id)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var lineForm = this.lines.EditViewData(id);

            return View(lineForm);
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult EditLine(Guid id, LineEditFormModel line)
        {

            var edited = this.lines.Edit(
                id,
                line.Name,
                line.Description);

            if (!edited)
            {
                return BadRequest();
            }

            TempData[MessageConstants.SuccessMessage] = "Линията беше успешно редактирана.";
            return RedirectToAction("All");
        }
    }
}
