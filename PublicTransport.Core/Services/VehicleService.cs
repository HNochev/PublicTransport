using PublicTransport.Core.Contracts;
using PublicTransport.Core.Models.Vehicles;
using PublicTransport.Infrastructure.Data;
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
                     Condition = x.Condition,
                 })
                 .OrderByDescending(x => x.InventoryNumber)
                 .ToList();
        }
    }
}
