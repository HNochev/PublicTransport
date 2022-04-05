using PublicTransport.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Lines
{
    public class LineAddStopToLineFormModel
    {
        [Display(Name = "Избери спирка която да добавиш като следваща с списъка за линията")]
        public Guid StopId { get; set; }

        public IEnumerable<LineStopModel> LineStops { get; set; }

        public IEnumerable<LineStopModel> AddedStopsForThisLine { get; set; }

        public LinesListingModel Line { get; set; }

        public int Orderer { get; set; }
    }
}
