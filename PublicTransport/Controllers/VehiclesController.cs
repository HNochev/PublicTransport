using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Core.Constants;
using PublicTransport.Core.Contracts;
using PublicTransport.Core.Extensions;
using PublicTransport.Core.Models.Photos;
using PublicTransport.Core.Models.Vehicles;
using PublicTransport.Infrastructure.Data;

namespace PublicTransport.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleService vehicles;
        private readonly IUserService users;
        private readonly IPhotoService photos;

        public VehiclesController(IVehicleService vehicles, IUserService users, IPhotoService photos)
        {
            this.vehicles = vehicles;
            this.users = users;
            this.photos = photos;
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

        [Authorize]
        public IActionResult AddPhoto(Guid id)
        {
            var pendingPhotosCount = this.users.UserPendingPhotosCount(this.User.Id());

            if (!User.IsInRole(UserConstants.Administrator))
            {
                if (pendingPhotosCount >= 3)
                {
                    TempData[MessageConstants.ErrorMessage] = "Вие имате поне 3 снимки изчакващи одобрение.";
                    return Redirect($"../../Vehicles/Details/{id}");
                }
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPhotoAsync(Guid id, PhotoAddFormModel photo)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var pendingStatusId = this.photos.GetPendingStatusId();

            byte[] fileArray = null;

            using (var memoryStream = new MemoryStream())
            {
                await photo.FileUpload.PhotoFile.CopyToAsync(memoryStream);

                string fileExt = Path.GetExtension(photo.FileUpload.PhotoFile.FileName.ToLower());

                if (fileExt == ".jpeg" || fileExt == ".jpg")
                {
                    // Upload the file if less than 2 MB
                    if (memoryStream.Length < 2097152)
                    {
                        fileArray = memoryStream.ToArray();
                    }
                    else
                    {
                        TempData[MessageConstants.ErrorMessage] = "Размерът на снимката е твърде голям! Моля качете снимка до 2MB!";
                        return Redirect(Request.Path);
                    }
                }
                else
                {
                    TempData[MessageConstants.ErrorMessage] = "Само .jpeg/.jpg файлове са разрешени!";
                    return Redirect(Request.Path);
                }
            }

            var photoId = this.photos.CreatePhoto(
                photo.Description,
                photo.DateOfPicture,
                DateTime.Now,
                photo.Location,
                photo.IsAuthor,
                photo.UserMessage,
                fileArray,
                pendingStatusId,
                userId,
                id,
                false
                );

            TempData[MessageConstants.SuccessMessage] = "Успешно добавихте снимка. Сега тя трябва да бъде одобрена, за да я видите в сайта.";
            return Redirect(Request.Path);
        }
    }
}
