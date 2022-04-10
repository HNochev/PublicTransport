using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Lines
{
    public class StopAddFormModel
    {
        [Required(ErrorMessage = "{0} е задължително поле")]
        [StringLength(50, ErrorMessage = "{0} трябва да бъде по-късo от {1} символа")]
        [Display(Name = "Име на спирката")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} е задължително поле")]
        [Range(0, 60, ErrorMessage = "{0} То трябва да бъде между {1} и {2} минути.")]
        [Display(Name = "Минути до предишна спирка. Ако спирката е начална 0.")]
        public int MinutesFromPreviousStop { get; set; }
    }
}
