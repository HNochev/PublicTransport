using System.ComponentModel.DataAnnotations;

namespace PublicTransport.Core.Models.News
{
    public class NewsAddFormModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Съдържание")]
        public string Description { get; set; }

        [Display(Name = "Линк изображение")]
        public string ImgUrl { get; set; }
    }
}
