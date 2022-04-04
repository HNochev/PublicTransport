using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Infrastructure.Data.Models
{
    public class Stop
    {
        public Stop()
        {
            this.Id = Guid.NewGuid();
            this.LineStops = new HashSet<LineStop>();
        }

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0, 60)]
        public int MinutesFromPreviousStop { get; set; }

        public ICollection<LineStop> LineStops { get; set; }
    }
}
