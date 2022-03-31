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

        [StringLength(500)]
        public string? Description { get; set; }

        public DateTime DateUploaded { get; set; }

        public DateTime DateOfPicture { get; set; }

        [StringLength(100)]
        public string? Location { get; set; }

        public bool IsAuthor { get; set; }

        [StringLength(500)]
        public string? UserMessage { get; set; }

        [StringLength(500)]
        public string? AdminMessage { get; set; }

        [Required]
        public Guid PhotoStatusId { get; set; }

        [ForeignKey(nameof(PhotoStatusId))]
        public PhotoStatus PhotoStatus { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public WebsiteUser User { get; set; }

        [Required]
        public Guid VehicleId { get; set; }

        [ForeignKey(nameof(VehicleId))]
        public Vehicle Vehicle { get; set; }

        public bool IsApproved { get; set; }

        [Required]
        public byte[] PhotoFile { get; set; }

        public ICollection<PhotoComment> PhotoComments { get; set; }
    }
}
