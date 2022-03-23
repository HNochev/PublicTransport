using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Infrastructure.Data.Models
{
    public class Photo
    {
        public Photo()
        {
            this.Id = Guid.NewGuid();
            this.PhotoComments = new HashSet<PhotoComment>();
        }

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public DateTime DateUploaded { get; set; }

        public DateTime DateOfPicture { get; set; }

        public bool IsAuthor { get; set; }

        [StringLength(500)]
        public string UserMessage { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public WebsiteUser Author { get; set; }

        [Required]
        public Guid VehicleId { get; set; }

        [ForeignKey(nameof(VehicleId))]
        public Vehicle Vehicle { get; set; }

        public ICollection<PhotoComment> PhotoComments { get; set; }
    }
}
