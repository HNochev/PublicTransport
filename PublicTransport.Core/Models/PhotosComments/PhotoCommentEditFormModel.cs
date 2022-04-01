using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.PhotosComments
{
    public class PhotoCommentEditFormModel
    {
        [Required]
        [StringLength(500)]
        [Display(Name = "Съдържание")]

        public string Content { get; set; }

        public DateTime LastEditedOn { get; set; }
    }
}
