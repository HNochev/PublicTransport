using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Core.Constants;
using PublicTransport.Core.Contracts;
using PublicTransport.Core.Extensions;
using PublicTransport.Core.Models.Vehicles;

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
                vehicle.VehicleConditionId,
                vehicle.YearBuilt,
                vehicle.Description,
                false);

            TempData[MessageConstants.SuccessMessage] = "Новината беше успешно добавена.";
            return RedirectToAction("All");
        }

    }
}
