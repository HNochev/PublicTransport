using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Core.Constants;
using PublicTransport.Core.Contracts;

namespace PublicTransport.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleService vehicles;

        public VehiclesController(IVehicleService vehicles)
        {
            this.vehicles = vehicles;
        }

        public IActionResult All()
        {
            var vehicles = this.vehicles.All();

            return View(vehicles);
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Add()
        {
            return View();
        }

    }
}
