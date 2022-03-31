using PublicTransport.Core.Models.Photos;
using PublicTransport.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Vehicles
{
    public class VehicleDetailsModel
    {
        public Guid Id { get; set; }

        public string InventoryNumber { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string FactoryNumber { get; set; }

        public int YearBuilt { get; set; }

        public DateTime ArriveInTown { get; set; }

        public DateTime? InUseSince { get; set; }

        public DateTime? InUseTo { get; set; }

        public string? Description { get; set; }

        public DateTime? ScrappedOn { get; set; }

        public Guid VehicleConditionId { get; set; }

        public VehicleCondition VehicleCondition { get; set; }

        public ICollection<PhotosForOneYearModel> PhotosForYear { get; set; }


    }
}
