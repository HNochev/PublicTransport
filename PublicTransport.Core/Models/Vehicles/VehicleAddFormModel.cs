using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Vehicles
{
    public class VehicleAddFormModel
    {
        [Required(ErrorMessage = "{0} е задължително поле")]
        [StringLength(10, ErrorMessage = "{0} трябва да бъде по-къс от {1} символа")]
        [Display(Name = "Инвентарен номер")]
        public string InventoryNumber { get; set; }

        [Required(ErrorMessage = "{0} е задължително поле")]
        [StringLength(25, ErrorMessage = "{0} трябва да бъде по-късa от {1} символа")]
        [Display(Name = "Марка")]
        public string Make { get; set; }

        [Required(ErrorMessage = "{0} е задължително поле")]
        [StringLength(25, ErrorMessage = "{0} трябва да бъде по-къс от {1} символа")]
        [Display(Name = "Модел")]
        public string Model { get; set; }

        [Required(ErrorMessage = "{0} е задължително поле")]
        [StringLength(15, ErrorMessage = "{0} трябва да бъде по-къс от {1} символа")]
        [Display(Name = "Заводски номер")]
        public string FactoryNumber { get; set; }

        [Required(ErrorMessage = "{0} е задължително поле")]
        [Range(1900, 2100, ErrorMessage = "{0} може да бъде между {1} и {2}")]
        [Display(Name = "Година на производство")]
        public int YearBuilt { get; set; }

        [Required(ErrorMessage = "{0} е задължително поле")]
        [DataType(DataType.Date)]
        [Display(Name = "Пристигнал в Хасково")]
        public DateTime ArriveInTown { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Начало на експлоатацията")]
        public DateTime? InUseSince { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Край на експлоатацията")]
        public DateTime? InUseTo { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Бракуван/Нарязан на")]
        public DateTime? ScrappedOn { get; set; }

        [StringLength(500, ErrorMessage = "{0} трябва да бъде по-късa от {1} символа")]
        [Display(Name = "Информация")]
        public string? Description { get; set; }

        [Display(Name = "Състояние")]
        public Guid VehicleConditionId { get; set; }

        public IEnumerable<VehicleConditionModel> VehicleConditions { get; set; }
    }
}
