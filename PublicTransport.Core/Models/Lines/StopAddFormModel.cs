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
        [Required]
        [StringLength(50)]
        [Display(Name = "Име на спирката")]
        public string Name { get; set; }

        [Required]
        [Range(0, 60)]
        [Display(Name = "Минути до предишна спирка. Ако спирката е начална 0.")]
        public int MinutesFromPreviousStop { get; set; }
    }
}
