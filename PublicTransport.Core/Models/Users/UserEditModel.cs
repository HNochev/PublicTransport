using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Users
{
    public class UserEditModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Потребителско име")]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Имейл")]
        public string? Email { get; set; }
    }
}
