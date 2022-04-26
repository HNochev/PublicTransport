using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Cards
{
    public class CardEditFormModel
    {
        [Required(ErrorMessage = "{0} е задължително поле")]
        [StringLength(500, ErrorMessage = "{0} трябва да бъдат по-къси от {1} символа")]
        [Display(Name = "Име и описание на картата")]
        public string Name { get; set; }
    }
}
