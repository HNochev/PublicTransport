using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Lines
{
    public class LineStopAddFormModel
    {
        [Required]
        public Guid LineId { get; set; }

        [Required]
        public Guid StopId { get; set; }

        public int Orderer { get; set; }
    }
}
