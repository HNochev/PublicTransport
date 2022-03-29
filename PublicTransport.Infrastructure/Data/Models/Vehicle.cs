using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public DateTime ArriveInTown { get; set; }

        public DateTime? InUseSince { get; set; }

        public DateTime? InUseTo { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public DateTime? ScrappedOn { get; set; }

        [Required]
        public Guid VehicleConditionId { get; set; }

        [ForeignKey(nameof(VehicleConditionId))]
        public VehicleCondition VehicleCondition { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public ICollection<Photo> Photos { get; set; }
    }
}
