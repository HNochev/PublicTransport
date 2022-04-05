using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Lines
{
    public class LineRemoveStartingHourFromLineFormModel
    {
        [Required]
        [Display(Name = "Изберете час на потегляне, който искате да премахнете и натиснете премахни")]
        public Guid StartingHourId { get; set; }

        public IEnumerable<LineHoursModel> StartingHours { get; set; }

        public LinesListingModel Line { get; set; }
    }
}
