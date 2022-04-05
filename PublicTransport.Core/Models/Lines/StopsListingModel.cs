using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Lines
{
    public class StopsListingModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int MinutesFromPreviousStop { get; set; }
    }
}
