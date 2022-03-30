using Microsoft.AspNetCore.Identity;

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
    }
}
