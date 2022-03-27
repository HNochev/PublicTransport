using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.NewsComments
{
    public class CommentAddFormModel
    {
        [Required]
        [StringLength(500)]
        [Display(Name = "Съдържание")]

        public string Content { get; set; }

        [Required]
        [Display(Name = "Индентификационен Номер")]
        public Guid NewsId { get; set; }
    }
}
