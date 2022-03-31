using Microsoft.EntityFrameworkCore;
using PublicTransport.Core.Contracts;
using PublicTransport.Core.Models.Photos;
using PublicTransport.Core.Models.Vehicles;
using PublicTransport.Infrastructure.Data;
using PublicTransport.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly ApplicationDbContext data;

        public VehicleService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public List<VehiclesListingModel> All()
        {
            return this.data
                 .Vehicles
                 .Where(x => !x.IsDeleted)
                 .Select(x => new VehiclesListingModel
                 {
                     Id = x.Id,
                     InventoryNumber = x.InventoryNumber,
                     Make = x.Make,
                     Model = x.Model,
                     FactoryNumber = x.FactoryNumber,
                     YearBuilt = x.YearBuilt,
                     ArriveInTown = x.ArriveInTown,
                     InUseSince = x.InUseSince,
                     InUseTo = x.InUseTo,
                     ScrappedOn = x.ScrappedOn,
                     VehicleConditionId = x.VehicleConditionId,
                     ClassColor = this.data.VehicleConditions
                                .Where(y => y.Id == x.VehicleConditionId)
                                .Select(y => y.ClassColor)
                                .First()
                 })
                 .OrderBy(x => x.InventoryNumber)
                 .ToList();
        }

        public IEnumerable<VehicleConditionModel> AllVehicleConditions()
        {
            return this.data
                .VehicleConditions
                .Select(x => new VehicleConditionModel
                {
                    Id = x.Id,
                    ConditionDescription = x.ConditionDescription,
                    ClassColor = x.ClassColor,
                    Counter = x.Counter,
                })
                .OrderBy(x => x.Counter)
                .ToList();
        }

        public Guid CreateVehicle(string inventoryNumber, string make, string model, string factoryNumber, DateTime arriveInTown, DateTime? inUseSince, DateTime? inUseTo, DateTime? scrappedOn, Guid vehicleConditionId, int yearBuilt, string? description, bool isDeleted)
        {
            var newVehicle = new Vehicle
            {
                InventoryNumber = inventoryNumber,
                Make = make,
                Model = model,
                FactoryNumber = factoryNumber,
                ArriveInTown = arriveInTown,
                InUseSince = inUseSince,
                InUseTo = inUseTo,
                ScrappedOn = scrappedOn,
                VehicleConditionId = vehicleConditionId,
                YearBuilt = yearBuilt,
                Description = description,
                IsDeleted = isDeleted,
            };

            this.data.Vehicles.Add(newVehicle);
            this.data.SaveChanges();

            return newVehicle.Id;
        }

        public VehicleDetailsModel Details(Guid id)
        {
            return this.data.Vehicles
                .Where(x => x.Id == id)
                .Select(x => new VehicleDetailsModel
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    InventoryNumber = x.InventoryNumber,
                    FactoryNumber = x.FactoryNumber,
                    ArriveInTown = x.ArriveInTown,
                    InUseSince = x.InUseSince,
                    InUseTo = x.InUseTo,
                    ScrappedOn = x.ScrappedOn,
                    Description = x.Description,
                    VehicleCondition = x.VehicleCondition,
                    VehicleConditionId = x.VehicleConditionId,
                    YearBuilt = x.YearBuilt,
                    PhotosForYear = x.Photos.Select(y => new PhotosForOneYearModel
                    {
                        Year = y.DateOfPicture.Year,
                        Photos = x.Photos.Select(z => new PhotosListingModel
                        {
                            Id = z.Id,
                            DateOfPicture = z.DateOfPicture,
                            DateUploaded = z.DateUploaded,
                            Location = z.Location,
                            UserId = z.UserId,
                            User = z.User,
                            ImgUrlFormDatabase = "data:image/jpg;base64," + Convert.ToBase64String(z.PhotoFile),
                        })
                        .Where(z => z.DateOfPicture.Year == y.DateOfPicture.Year)
                        .OrderByDescending(z => z.DateOfPicture)
                        .ToList()
                    })
                    .OrderByDescending(y => y.Year)
                    .ToList()
                })
                .First();
        }

        public bool Edit(Guid id, string inventoryNumber, string make, string model, string factoryNumber, DateTime arriveInTown, DateTime? inUseSince, DateTime? inUseTo, DateTime? scrappedOn, Guid vehicleConditionId, int yearBuilt, string? description)
        {
            var newsData = this.data.Vehicles.Find(id);

            if (newsData == null)
            {
                return false;
            }

            newsData.InventoryNumber = inventoryNumber;
            newsData.Make = make;
            newsData.Model = model;
            newsData.FactoryNumber = factoryNumber;
            newsData.ArriveInTown = arriveInTown;
            newsData.InUseSince = inUseSince;
            newsData.InUseTo = inUseTo;
            newsData.ScrappedOn = scrappedOn;
            newsData.VehicleConditionId = vehicleConditionId;
            newsData.YearBuilt = yearBuilt;
            newsData.Description = description;

            this.data.SaveChanges();

            return true;
        }

        public bool Delete(Guid id, bool isDeleted)
        {
            var vehicleData = this.data.Vehicles.Find(id);

            if (vehicleData == null)
            {
                return false;
            }

            vehicleData.IsDeleted = isDeleted;

            this.data.SaveChanges();

            return true;
        }

        public VehicleDeleteModel DeleteViewData(Guid id)
        {
            return this.data.Vehicles
                .Where(x => x.Id == id)
                .Select(x => new VehicleDeleteModel
                {
                    InventoryNumber = x.InventoryNumber,
                    Make = x.Make,
                    Model = x.Model,
                    YearBuilt = x.YearBuilt,
                    FactoryNumber = x.FactoryNumber,
                })
                .First();
        }

        public VehicleAddFormModel EditViewData(Guid id)
        {
            return this.data.Vehicles
                .Where(x => x.Id == id)
                .Select(x => new VehicleAddFormModel
                {
                    InventoryNumber = x.InventoryNumber,
                    Make = x.Make,
                    Model = x.Model,
                    FactoryNumber = x.FactoryNumber,
                    YearBuilt = x.YearBuilt,
                    ArriveInTown = x.ArriveInTown,
                    InUseSince = x.InUseSince,
                    InUseTo = x.InUseTo,
                    ScrappedOn = x.ScrappedOn,
                    Description = x.Description,
                    VehicleConditionId = x.VehicleConditionId,
                })
                .First();
        }
    }
}
