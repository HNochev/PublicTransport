using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Vehicles
{
    public class VehicleDeleteModel
    {
        public string InventoryNumber { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string FactoryNumber { get; set; }

        public int YearBuilt { get; set; }
    }
}
