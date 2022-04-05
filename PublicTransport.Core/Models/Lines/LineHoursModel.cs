using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Lines
{
    public class LineHoursModel
    {
        public Guid Id { get; set; }

        public DateTime StartHour { get; set; }
    }
}
