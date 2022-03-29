using PublicTransport.Core.Contracts;
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
                 .Select(x => new VehiclesListingModel
                 {
                     Id = x.Id,
                     InventoryNumber = x.InventoryNumber,
                     Make = x.Make,
                     Model = x.Model,
                     FactoryNumber = x.FactoryNumber,
                     YearBuilt = x.YearBuilt,
                     InUseSince = x.InUseSince,
                     InUseTo = x.InUseTo,
                     IsScrapped = x.IsScrapped,
                     ScrappedOn = x.ScrappedOn,
                 })
                 .OrderByDescending(x => x.InventoryNumber)
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

        public Guid CreateVehicle(string inventoryNumber, string make, string model, string factoryNumber, DateTime? arriveInTown, DateTime? inUseSince, DateTime? inUseTo, Guid vehicleConditionId, int yearBuilt, string? description, bool isScrapped)
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
                VehicleConditionId = vehicleConditionId,
                YearBuilt = yearBuilt,
                Description = description,
                IsScrapped = isScrapped,
            };

            this.data.Vehicles.Add(newVehicle);
            this.data.SaveChanges();

            return newVehicle.Id;
        }
    }
}
