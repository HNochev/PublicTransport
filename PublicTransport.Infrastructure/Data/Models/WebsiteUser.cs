using Microsoft.AspNetCore.Identity;

namespace PublicTransport.Infrastructure.Data.Models
{
    public class WebsiteUser : IdentityUser
    {
        public DateTime RegisteredOn { get; set; }

        public ICollection<NewsComment> NewsComments { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public ICollection<PhotoComment> PhotoComments { get; set; }
    }
}
