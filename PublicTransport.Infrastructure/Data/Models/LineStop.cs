using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Infrastructure.Data.Models
{
    public class LineStop
    {
        [Required]
        public Guid LineId { get; set; }

        [ForeignKey(nameof(LineId))]
        public Line Line { get; set; }

        [Required]
        public Guid StopId { get; set; }

        [ForeignKey(nameof(StopId))]
        public Stop Stop { get; set; }
    }
}
