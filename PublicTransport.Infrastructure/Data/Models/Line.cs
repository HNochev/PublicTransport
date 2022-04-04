using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Infrastructure.Data.Models
{
    public class Line
    {
        public Line()
        {
            this.Id = Guid.NewGuid();
            this.LineStops = new HashSet<LineStop>();
        }

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public WebsiteUser User { get; set; }

        public ICollection<LineStop> LineStops { get; set; }
    }
}
