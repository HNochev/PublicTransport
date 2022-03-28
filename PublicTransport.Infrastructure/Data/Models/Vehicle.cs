using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Infrastructure.Data.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            this.Id = Guid.NewGuid();
            this.Photos = new HashSet<Photo>();
        }

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string InventoryNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Make { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [StringLength(100)]
        public string FactoryNumber { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int YearBuilt { get; set; }

        [Required]
        public DateTime InUseSince { get; set; }

        public DateTime? InUseTo { get; set; }

        [Required]
        [StringLength(50)]
        public string Condition { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public bool IsScrapped { get; set; }

        public DateTime? ScrappedOn { get; set; }

        public ICollection<Photo> Photos { get; set; }
    }
}
