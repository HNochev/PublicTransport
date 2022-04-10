using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Lines
{
    public class HourAddFormModel
    {
        [Required(ErrorMessage = "{0} е задължително поле")]
        [DataType(DataType.Time)]
        [Display(Name = "Час на тръгване от началната спирка")]
        public DateTime StartHour { get; set; }

        [Required(ErrorMessage = "{0} е задължително поле")]
        public string Name { get; set; }

        public Guid Id { get; set; }
    }
}
