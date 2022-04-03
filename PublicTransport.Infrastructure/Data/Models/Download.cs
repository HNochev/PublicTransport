using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Infrastructure.Data.Models
{
    public class Download
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public WebsiteUser User { get; set; }

        [Required]
        public byte[] FilePDF { get; set; }
    }
}
