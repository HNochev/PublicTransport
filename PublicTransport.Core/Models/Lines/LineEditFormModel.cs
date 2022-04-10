using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Lines
{
    public class LineEditFormModel
    {
        [Required(ErrorMessage = "{0} е задължително поле")]
        [StringLength(10, ErrorMessage = "{0} трябва да бъде по-късo от {1} символа")]
        [Display(Name = "Номер на линията")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} е задължително поле")]
        [StringLength(100, ErrorMessage = "{0} трябва да бъде по-късo от {1} символа")]
        [Display(Name = "Съкратен маршрут на линията")]
        public string Description { get; set; }
    }
}
