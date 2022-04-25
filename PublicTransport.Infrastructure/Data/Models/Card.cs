using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Infrastructure.Data.Models
{
    public class Card
    {
        public Card()
        {
            this.Id = Guid.NewGuid();
            this.Users = new HashSet<WebsiteUser>();
        }

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [Required]
        [Range(0, 1000)]
        public int DaysActive { get; set; }

        [Required]
        [Range(0, 1000.00)]
        public decimal Price { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public ICollection<WebsiteUser> Users { get; set; }
    }
}
