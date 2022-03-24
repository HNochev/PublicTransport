using System.ComponentModel.DataAnnotations;

namespace PublicTransport.Models.News
{
    public class NewsAddFormModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Съдържание")]
        public string Description { get; set; }
    }
}
