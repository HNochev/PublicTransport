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
        [Required]
        [StringLength(100)]
        [Display(Name = "Инвентарен номер")]
        public string InventoryNumber { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Марка")]
        public string Make { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Модел")]
        public string Model { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Заводски номер")]
        public string FactoryNumber { get; set; }

        [Required]
        [Range(1900, 2100)]
        [Display(Name = "Година на производство")]
        public int YearBuilt { get; set; }

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

        [StringLength(500)]
        [Display(Name = "Информация")]
        public string? Description { get; set; }

        [Display(Name = "Състояние")]
        public Guid VehicleConditionId { get; set; }

        public IEnumerable<VehicleConditionModel> VehicleConditions { get; set; }
    }
}
