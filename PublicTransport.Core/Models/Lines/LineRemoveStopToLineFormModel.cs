using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Lines
{
    public class LineRemoveStopToLineFormModel
    {
        [Required(ErrorMessage = "{0} е задължително поле")]
        [Display(Name = "Изберете спирка, която искате да премахнете и натиснете премахни")]
        public Guid StopId { get; set; }

        public IEnumerable<LineStopModel> LineStops { get; set; }

        public LinesListingModel Line { get; set; }
    }
}
