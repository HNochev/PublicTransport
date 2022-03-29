using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Core.Constants;
using PublicTransport.Core.Contracts;
using PublicTransport.Core.Extensions;
using PublicTransport.Core.Models.Vehicles;
using PublicTransport.Infrastructure.Data;

namespace PublicTransport.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleService vehicles;
        private readonly IUserService users;

        public VehiclesController(IVehicleService vehicles, IUserService users)
        {
            this.vehicles = vehicles;
            this.users = users;
        }

        public IActionResult All()
        {
            var vehicles = this.vehicles.All();

            return View(vehicles);
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Add()
        {
            return View(new VehicleAddFormModel
            {
                VehicleConditions = this.vehicles.AllVehicleConditions()
            });
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Add(VehicleAddFormModel vehicle)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var newsId = this.vehicles.CreateVehicle(
                vehicle.InventoryNumber,
                vehicle.Make,
                vehicle.Model,
                vehicle.FactoryNumber,
                vehicle.ArriveInTown,
                vehicle.InUseSince,
                vehicle.InUseTo,
                vehicle.ScrappedOn,
                vehicle.VehicleConditionId,
                vehicle.YearBuilt,
                vehicle.Description,
                false);

            TempData[MessageConstants.SuccessMessage] = "Превозното средство беше успешно добавено.";
            return RedirectToAction("All");
        }

        public IActionResult Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var vehicles = this.vehicles.Details(id);

            if (vehicles == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction("All");
            }

            return View(vehicles);
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

            var vehicles = this.vehicles.Details(id);

            var vehiclesForm = this.vehicles.EditViewData(vehicles.Id);

            vehiclesForm.VehicleConditions = this.vehicles.AllVehicleConditions();

            return View(vehiclesForm);
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Edit(Guid id, VehicleAddFormModel vehicle)
        {

            var edited = this.vehicles.Edit(
                id,
                vehicle.InventoryNumber,
                vehicle.Make,
                vehicle.Model,
                vehicle.FactoryNumber,
                vehicle.ArriveInTown,
                vehicle.InUseSince,
                vehicle.InUseTo,
                vehicle.ScrappedOn,
                vehicle.VehicleConditionId,
                vehicle.YearBuilt,
                vehicle.Description
                );

            if (!edited)
            {
                return BadRequest();
            }

            TempData[MessageConstants.SuccessMessage] = "Тролейбусът беше успешно редактиран.";
            return Redirect($"../../Vehicles/Details/{id}");
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

            var vehicle = this.vehicles.Details(id);

            var vehicleForm = this.vehicles.DeleteViewData(vehicle.Id);

            return View(vehicleForm);
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Delete(Guid id, VehicleDeleteModel vehicle)
        {

            var deleted = this.vehicles.Delete(id, true);

            if (!deleted)
            {
                return BadRequest();
            }

            TempData[MessageConstants.SuccessMessage] = "Тролейбусът беше успешно изтрит.";
            return RedirectToAction("All");
        }
    }
}
