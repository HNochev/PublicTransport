using PublicTransport.Core.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Contracts
{
    public interface IVehicleService
    {
        public List<VehiclesListingModel> All();

        public IEnumerable<VehicleConditionModel> AllVehicleConditions();

        public Guid CreateVehicle(
            string inventoryNumber,
            string make,
            string model,
            string factoryNumber,
            DateTime arriveInTown,
            DateTime? inUseSince,
            DateTime? inUseTo,
            DateTime? scrappedOn,
            Guid vehicleConditionId,
            int yearBuilt,
            string? description,
            bool isDeleted
            );

        public VehicleDetailsModel Details(Guid id);

        public bool Edit(
           Guid id,
           string inventoryNumber,
           string make,
           string model,
           string factoryNumber,
           DateTime arriveInTown,
           DateTime? inUseSince,
           DateTime? inUseTo,
           DateTime? scrappedOn,
           Guid vehicleConditionId,
           int yearBuilt,
           string? description
           );

        public bool Delete(Guid id, bool isDeleted);
    }
}
