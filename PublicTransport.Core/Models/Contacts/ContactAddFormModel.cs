using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Contacts
{
    public class ContactAddFormModel
    {
        [Required]
        [StringLength(60)]
        [Display(Name = "Име и фамилия")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(10)]
        [Display(Name = "Телефонен номер")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Длъжност")]
        public string Position { get; set; }


        [StringLength(50, MinimumLength = 6)]
        [Display(Name = "Потребителско име в сайта")]
        public string? UsernameInWebsite { get; set; }
    }
}
