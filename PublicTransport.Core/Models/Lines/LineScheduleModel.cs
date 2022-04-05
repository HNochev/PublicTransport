using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Lines
{
    public class LineScheduleModel
    {
        public LinesListingModel Line { get; set; }

        public IEnumerable<LineStopModel> AllStopsForThisLine { get; set; }

        public IEnumerable<LineHoursModel> AllStartingHoursForThisLine { get; set; }
    }
}
