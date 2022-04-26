using PublicTransport.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Users
{
    public class UserDetailsModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

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
