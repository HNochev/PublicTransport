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
            return RedirectToAction("AddStop");
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

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult AddStopToLine(Guid id)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            return View(new LineAddStopToLineFormModel
            {
                LineStops = this.lines.AllStops(),
                AddedStopsForThisLine = this.lines.AllAddedStops(id),
                Line = this.lines.GetLineInfo(id),
            });
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult AddStopToLine(Guid id, LineStopAddFormModel lineStop)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var added = this.lines.AddLineStop(id, lineStop.StopId);

            if (!added)
            {
                TempData[MessageConstants.ErrorMessage] = "Тази спирка е вече добавена за линията";
                return Redirect(Request.Path);
            }

            TempData[MessageConstants.SuccessMessage] = "Успешно добавитхе спирката.";
            return Redirect(Request.Path);
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult RemoveStopFromLine(Guid id)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            return View(new LineRemoveStopToLineFormModel
            {
                LineStops = this.lines.AllAddedStops(id),
                Line = this.lines.GetLineInfo(id),
            });
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult RemoveStopFromLine(Guid id, LineStopAddFormModel lineStop)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var removed = this.lines.RemoveLineStop(id, lineStop.StopId);

            if (!removed)
            {
                TempData[MessageConstants.ErrorMessage] = "Тази спирка е вече премахната за линията";
                return Redirect(Request.Path);
            }

            TempData[MessageConstants.SuccessMessage] = "Спирката беше успешно премахната";
            return Redirect(Request.Path);
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult AllCreatedStops()
        {
            var stops = this.lines.AllCreatedStops();

            return View(stops);
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult RemoveStop(Guid id)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var deleted = this.lines.DeleteStop(id);

            if (!deleted)
            {
                TempData[MessageConstants.ErrorMessage] = "Тази спирка не може да бъде изтрита понеже е свързана с линия. Моля първо отидете и изтрийте спирката от там.";
                return Redirect("../../Lines/AllCreatedStops");
            }

            TempData[MessageConstants.SuccessMessage] = "Успешно изтрхте спирката.";
            return Redirect("../../Lines/AllCreatedStops");
        }

        public IActionResult Schedule(Guid id)
        {
            return View(new LineScheduleModel
            {
                AllStopsForThisLine = this.lines.AllAddedStops(id),
                Line = this.lines.GetLineInfo(id),
                AllStartingHoursForThisLine = this.lines.GetAllHoursForLine(id),
            });
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult AddStartingHourToLine(Guid id)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            return View(new HourAddFormModel
            {
                Name = this.lines.GetLineInfo(id).Name,
                Id = id,
            });
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult AddStartingHourToLine(Guid id, HourAddFormModel hour)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var added = this.lines.AddStartingHourToLine(id, hour.StartHour);

            if (!added)
            {
                TempData[MessageConstants.ErrorMessage] = "Този час е вече добавен за тази линия";
                return Redirect(Request.Path);
            }

            TempData[MessageConstants.SuccessMessage] = "Успешно добавитхе спирката.";
            return Redirect($"../../Lines/Schedule/{id}");
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult RemoveStartingHourFromLine(Guid id)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            return View(new LineRemoveStartingHourFromLineFormModel
            {
                StartingHours = this.lines.AllStartingHours(id),
                Line = this.lines.GetLineInfo(id),
            });
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult RemoveStartingHourFromLine(Guid id, LineRemoveStartingHourFromLineFormModel hour)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var removed = this.lines.RemoveHourFromLine(hour.StartingHourId);

            if (!removed)
            {
                TempData[MessageConstants.ErrorMessage] = "Този час е вече премахнат за линията";
                return Redirect(Request.Path);
            }

            TempData[MessageConstants.SuccessMessage] = "Часът на потегляне успешно премахнат";
            return Redirect(Request.Path);
        }
    }
}
