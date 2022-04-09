﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Lines
{
    public class LineAddFormModel
    {
        [Required]
        [StringLength(10)]
        [Display(Name = "Номер на линията")]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Съкратен маршрут на линията")]
        public string Description { get; set; }

        [Display(Name = "В движение ли е тази линия?")]
        public bool IsActive { get; set; }
    }
}