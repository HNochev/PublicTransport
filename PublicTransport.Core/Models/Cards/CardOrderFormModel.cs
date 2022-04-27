using PublicTransport.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Cards
{
    public class CardOrderFormModel
    {
        [Required(ErrorMessage = "{0} е задължително поле")]
        public Guid? CardId { get; set; }

        [Required(ErrorMessage = "{0} е задължително поле")]
        [ForeignKey(nameof(CardId))]
        public Card? Card { get; set; }

        [Required(ErrorMessage = "{0} е задължително поле")]
        [StringLength(100, ErrorMessage = "{0} трябва да бъде по-късо от {1} символа")]
        [Display(Name = "Име на ползвателя на картата")]
        public string? CardOwnerFirstName { get; set; }

        [Required(ErrorMessage = "{0} е задължително поле")]
        [StringLength(100, ErrorMessage = "{0} трябва да бъде по-къса от {1} символа")]
        [Display(Name = "Фамилия на ползвателя на картата")]
        public string? CardOwnerLastName { get; set; }
    }
}
