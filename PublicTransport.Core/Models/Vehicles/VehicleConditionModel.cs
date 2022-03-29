using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Vehicles
{
    public class VehicleConditionModel
    {
        public Guid Id { get; set; }

        public string ConditionDescription { get; set; }

        public string ClassColor { get; set; }

        public int Counter { get; set; }
    }
}
