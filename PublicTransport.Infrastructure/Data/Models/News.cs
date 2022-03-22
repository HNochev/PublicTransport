using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PublicTransport.Infrastructure.Data.Models
{
    public class News
    {
        public News()
        {
            this.Id = Guid.NewGuid();
            this.NewsComments = new HashSet<NewsComments>();
        }

        [Key]
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public WebsiteUser Author { get; set; }

        public ICollection<NewsComments> NewsComments { get; set; }
    }
}
