using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PublicTransport.Infrastructure.Data.Models
{
    public class WebsiteUser : IdentityUser
    {
        public WebsiteUser()
        {
            this.NewsComments = new HashSet<NewsComment>();
            this.Photos = new HashSet<Photo>();
            this.PhotoComments = new HashSet<PhotoComment>();
        }
        public DateTime RegisteredOn { get; set; }

        public ICollection<NewsComment> NewsComments { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public ICollection<PhotoComment> PhotoComments { get; set; }


        public bool? CardIsRequested { get; set; }

        public DateTime? CardRequestedOn { get; set; }

        public bool? CardIsActive { get; set; }

        public DateTime? CardActiveFrom { get; set; }

        public DateTime? CardActiveTo { get; set; }

        public Guid? CardId { get; set; }

        [ForeignKey(nameof(CardId))]
        public Card? Card { get; set; }
    }
}
