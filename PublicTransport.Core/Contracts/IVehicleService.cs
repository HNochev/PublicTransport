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
    }
}
