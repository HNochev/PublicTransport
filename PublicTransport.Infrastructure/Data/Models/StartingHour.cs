using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Infrastructure.Data.Models
{
    public class StartingHour
    {
        public StartingHour()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        [Required]
        public Guid Id { get; set; }

        public DateTime StartHour { get; set; }

        [Required]
        public Guid LineId { get; set; }

        [ForeignKey(nameof(LineId))]
        public Line Line { get; set; }


    }
}
