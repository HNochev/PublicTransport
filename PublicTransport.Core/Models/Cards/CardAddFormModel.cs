using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Cards
{
    public class CardAddFormModel
    {
        [Required(ErrorMessage = "{0} е задължително поле")]
        [StringLength(500, ErrorMessage = "{0} трябва да бъдат по-къси от {1} символа")]
        [Display(Name = "Име и описание на картата")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} е задължително поле")]
        [Range(0, 1000, ErrorMessage = "{0} трябва да бъде по-дълга от {1} и по-кратка от {2}")]
        [Display(Name = "Продължителност на активност в дни")]
        public int DaysActive { get; set; }

        [Required(ErrorMessage = "{0} е задължително поле")]
        [Range(0, 1000.00, ErrorMessage = "{0} трябва да бъде между от {1} и {2}")]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
    }
}
