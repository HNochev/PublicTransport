using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Infrastructure.Data.Models
{
    public class VehicleCondition
    {
        public VehicleCondition()
        {
            this.Id = Guid.NewGuid();
            this.Vehicles = new HashSet<Vehicle>();
        }

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ConditionDescription { get; set; }

        [Required]
        [StringLength(50)]
        public string ClassColor { get; set; }

        [Required]
        [Range(0, 50)]
        public int Counter { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
